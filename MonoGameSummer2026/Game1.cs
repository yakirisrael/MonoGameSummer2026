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

    private Player _player;
    private MouseText _mouseText = new();
    
    public static Vector2 ScreenSize = new Vector2(1920, 1080);
    
    
    SpriteManager _spriteManager;
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

       // _spriteManager = new SpriteManager(Content);
       
       SpriteManager._content = Content;

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
        
        SpriteManager.AddSprite("pacman", "Images/pacman");
        
        SpriteManager.AddSprite("GreenBird", "Images/Birds/B4_s3", 4,4 );
        SpriteManager.AddSprite("Duck1", "Images/Birds/Bird2 Duck_1", 4, 4);

        _mouseText._font = _fontOswald;
        
        Init();
    }

    void Init()
    {
        _player = new Player();
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
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}