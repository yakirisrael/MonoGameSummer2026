using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSummer2026;

public class Collider : Sprite
{
    public bool isTrigger { get; set; } = false;

    public Action<Collider, Collider> onTrigger;
    public Action<Collider, Collider> onCollision;

    public Sprite Parent { get; set; } 

    public Collider() : base("Pixel")
    { }

    public bool IsColliding(Collider otherCollider)
    {
        return _rect.Intersects(otherCollider._rect);
    }

    void Notify(Collider other)
    {
        if (isTrigger)
            onTrigger?.Invoke(this, other);
        else
            onCollision?.Invoke(this, other);
    }
    
    public override void Update(GameTime gameTime)
    {
        if (Parent == null) return;
        
        _rect = Parent._rect;

        // go on all colliders and check if intersect with them
        // while ignore self
        for (int i = 0; i < SceneManager.colliders.Count; i++)
        {
            Collider other = SceneManager.colliders[i];
            
            if (other != this && IsColliding(other))
                Notify(other);
        }
        
        base.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {

#if DEBUG
        // draw outline bounds
        int thickness = 5;
        Color color = Color.Green;
        
        // top
        spriteBatch.Draw(_texture,
            new Rectangle(
                _rect.X,
                _rect.Y,
                _rect.Width,
                thickness
            ), 
            color);
        
        // left
        spriteBatch.Draw(_texture,
            new Rectangle(
                _rect.X,
                _rect.Y,
                thickness,
                _rect.Height
            ), 
            color);
        
        // right
        spriteBatch.Draw(_texture,
            new Rectangle(
                _rect.X + _rect.Width - thickness,
                _rect.Y,
                thickness,
                _rect.Height
            ), 
            color);
        
        // bottom
        spriteBatch.Draw(_texture,
            new Rectangle(
                _rect.X,
                _rect.Y + _rect.Height - thickness,
                _rect.Width,
                thickness
            ), 
            color);
#endif        
    }
}