using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGameSummer2026;

public class MouseText : Text
{
    public override void Update(GameTime gameTime)
    {
        MouseState mouseInput = Mouse.GetState();

        _text = "(" + mouseInput.X + "," + mouseInput.Y + ")";
        _transform._position = Game1.ScreenSize - new Vector2(300, 300);
        
        base.Update(gameTime);
    }
}