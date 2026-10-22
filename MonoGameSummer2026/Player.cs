using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameSummer2026;

public class Player : Animation
{
    public float speed = 0.5f;
    
    Vector2 originalScale = Vector2.One;
    public Player() : base("Duck1")
    {
        _transform._position =  new Vector2(100, 200);
        _transform._angle = 0;
        _transform._scale = new Vector2(0.2f, 0.2f);

        _color = Color.White;

        originalScale = _transform._scale;
        
        _effects = SpriteEffects.FlipHorizontally;
        

    }


    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

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

    }


}