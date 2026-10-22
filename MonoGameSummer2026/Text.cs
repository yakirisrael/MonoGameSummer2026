using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSummer2026;

public class Text : IDrawable, IUpdatable
{
    public Transform _transform { get; set; } = new();
    public string _text { get; set; }

    public Vector2 _textSize { get; set; } = Vector2.Zero;
    
    public Color _color { get; set; } = Color.White;
    
    public SpriteFont _font { get; set; } 

    public virtual void Update(GameTime gameTime)
    {
        if (_text == null)  return;
        
        _textSize = _font.MeasureString(_text);
    }
    
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(
            _font,
            _text,
            _transform._position,
            _color,
            MathHelper.ToRadians(_transform._angle),
            _textSize * 0.5f,
            Vector2.One, 
            SpriteEffects.None,
            0);
    }
    
}