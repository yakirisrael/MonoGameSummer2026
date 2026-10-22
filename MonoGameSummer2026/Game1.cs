using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameSummer2026;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D _logoTexture;
    Texture2D _pongTexture;
    Texture2D _pacmanTexture;

    private SpriteFont _fontOswald;

    private Player _player = new();
    private MouseText _mouseText = new();
    
    public static Vector2 ScreenSize = new Vector2(1920, 1080);
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
        _graphics.IsFullScreen = true;
        
        _graphics.PreferredBackBufferHeight = 1080;
        _graphics.PreferredBackBufferWidth = 1920;

        ScreenSize.X = _graphics.PreferredBackBufferWidth;
        ScreenSize.Y = _graphics.PreferredBackBufferHeight;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        _fontOswald = Content.Load<SpriteFont>("Fonts/OswaldRegular");
        
        _logoTexture = Content.Load<Texture2D>("Images/logo");
        _pongTexture = Content.Load<Texture2D>("Images/pong-atlas");
        _pacmanTexture = Content.Load<Texture2D>("Images/pacman");

        _player._texture = _pacmanTexture;

        _mouseText._font = _fontOswald;
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _player.Update(gameTime);
        _mouseText.Update(gameTime);
        
        // TODO: Add your update logic here

        base.Update(gameTime);
        
    }
    
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();

        _player.Draw(_spriteBatch);
        _mouseText.Draw(_spriteBatch);
        
        /*_spriteBatch.Draw(_pongTexture,
            Vector2.Zero, 
            new Rectangle(
                new Point(0, 0), 
                new Point(
                    (int)(_pongTexture.Width * 0.5f),
                    _pongTexture.Height)
            ),
            Color.White,
            MathHelper.ToRadians(0),
            Vector2.Zero, 
            new Vector2(1f, 1f), 
            SpriteEffects.None,
            0
        );*/
       
        _spriteBatch.Draw(_logoTexture,
                         ScreenSize * 0.5f,
                         null,
                         Color.White,
                         MathHelper.ToRadians((float)gameTime.TotalGameTime.TotalMilliseconds),
                         _logoTexture.Bounds.Center.ToVector2(),
                         new Vector2(0.5f, 0.5f), 
                         SpriteEffects.None,
                         0
                         );
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}