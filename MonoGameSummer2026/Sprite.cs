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

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture,
            _transform._position, 
            new Rectangle(
                new Point(0, 0), 
                new Point(
                    _texture.Width,
                    _texture.Height)
            ),
            _color,
            MathHelper.ToRadians(_transform._angle),
            _origin, 
            _transform._scale, 
            SpriteEffects.None,
            sortingLayer
        );
    }

    public virtual void Update(GameTime gameTime)
    {
        
    }
}