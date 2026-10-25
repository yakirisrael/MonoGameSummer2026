using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameSummer2026;

public class Player : Animation
{
    public float speed = 0.5f;
    
    Vector2 originalScale = Vector2.One;

    Vector2 prevPosition = Vector2.Zero;
    public Collider collider { get; set; }

    public Player() : base("Duck1")
    {
        _transform._position =  new Vector2(100, 200);
        _transform._angle = 0;
        _transform._scale = new Vector2(0.2f, 0.2f);

        _color = Color.White;

        originalScale = _transform._scale;
        
        _effects = SpriteEffects.FlipHorizontally;
        
        collider = SceneManager.Create<Collider>();
        collider.Parent = this;
        
        PlayAnimation(true, 60);
    }


    public override void Update(GameTime gameTime)
    {
        prevPosition = _transform._position;
        
        if (Keyboard.GetState(0).IsKeyDown(Keys.D))
        {
            _transform._position = new Vector2(_transform._position.X + (float)gameTime.ElapsedGameTime.TotalMilliseconds * speed, _transform._position.Y);
            _effects = SpriteEffects.FlipHorizontally;
        }
        
        if (Keyboard.GetState(0).IsKeyDown(Keys.A))
        {
            _transform._position = new Vector2(_transform._position.X - (float)gameTime.ElapsedGameTime.TotalMilliseconds * speed, _transform._position.Y); 
            _effects = SpriteEffects.None;

        }
        
        if (Keyboard.GetState(0).IsKeyDown(Keys.W))
        {
            _transform._position = new Vector2(_transform._position.X, _transform._position.Y - (float)gameTime.ElapsedGameTime.TotalMilliseconds * speed);
        }
        
        if (Keyboard.GetState(0).IsKeyDown(Keys.S))
        {
            _transform._position = new Vector2(_transform._position.X, _transform._position.Y + (float)gameTime.ElapsedGameTime.TotalMilliseconds * speed);
        }

        if (Keyboard.GetState(0).IsKeyDown(Keys.P))
        {
            ChangeAnimation("GreenBird");
            PlayAnimation(true, 30);
        }
        
        // must be at the end so colliders won't get stuck
        base.Update(gameTime);
    }

    public void HandleCollision(Collider colliding, Collider other)
    {
        _transform._position = prevPosition;
    }
    
    public void HandleTrigger(Collider colliding, Collider other)
    {
        if (colliding.Parent is Enemy enemy)
        {
            if (enemy.collider != null)
                SceneManager.Remove(enemy.collider);
            
            SceneManager.Remove(enemy);
        }
    }
}