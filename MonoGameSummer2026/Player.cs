using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGameSummer2026;

public class Player : Sprite
{
    public float speed = 0.5f;
    public Player()
    {
        _transform._position =  new Vector2(100, 200);
        _transform._angle = 0;
        _transform._scale = new Vector2(0.2f, 0.2f);

        _color = Color.White;
    }


    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (Keyboard.GetState(0).IsKeyDown(Keys.D))
        {
            _transform._position = new Vector2(_transform._position.X + (float)gameTime.ElapsedGameTime.TotalMilliseconds * speed, _transform._position.Y);
        }

    }


}