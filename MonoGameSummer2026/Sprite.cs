using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSummer2026;

public class Sprite : IDrawable, IUpdatable
{
    public Transform _transform { get; set; } = new();
    public Texture2D _texture { get; set; }
    public Color _color { get; set; } = Color.White;

    public Vector2 _origin { get; set; } = Vector2.Zero;
    public int sortingLayer { get; set; } = 0;
    
    public SpriteEffects _effects { get; set; } = SpriteEffects.None;
    
    public Rectangle _sourceRectangle { get; set; }

    public Sprite(string SpriteName)
    {
        Spritesheet ss = SpriteManager.GetSprite(SpriteName);
        _sourceRectangle = ss[0, 0];
        _texture = ss.texture;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (_texture == null) return;
        
        spriteBatch.Draw(_texture,
            _transform._position, 
            _sourceRectangle,
            _color,
            MathHelper.ToRadians(_transform._angle),
            _origin, 
            _transform._scale, 
            _effects,
            sortingLayer
        );
    }

    public virtual void Update(GameTime gameTime)
    {
        
    }
}