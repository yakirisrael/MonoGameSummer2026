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
    
    private MouseText _mouseText = new();
    
    public static Vector2 ScreenSize = new Vector2(1920, 1080);
    
    SpriteManager _spriteManager = null;
    AudioManager _audioManager = null;
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        // prevent window focus when exit full screen
        _graphics.HardwareModeSwitch = false; 
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
        
        _spriteManager = new SpriteManager(Content);
        _audioManager = new AudioManager(Content); 
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        _fontOswald = Content.Load<SpriteFont>("Fonts/OswaldRegular");
        _mouseText._font = _fontOswald;

        AudioManager.AddSong("Theme", "Audio/theme");
        AudioManager.AddSoundEffect("Collect", "Audio/collect");
        AudioManager.AddSoundEffect("Bounce", "Audio/bounce");
       
        SpriteManager.AddSprite("Pixel", "Images/pixel");
        SpriteManager.AddSprite("Duck1", "Images/Birds/Bird2 Duck_1", 4, 4);
        SpriteManager.AddSprite("Duck2", "Images/Birds/Bird2 Duck_3", 4, 4);
        SpriteManager.AddSprite("Egret1", "Images/Birds/Bird3_Egret2", 4, 4);
        SpriteManager.AddSprite("Egret2", "Images/Birds/Bird3_Egret4", 4, 4);
        SpriteManager.AddSprite("GreenBird", "Images/Birds/B4_s3", 4,4 );
       
        Init();
    }

    void Init()
    {
        Player p = SceneManager.Create<Player>();
        Enemy e = SceneManager.Create<Enemy>();

        e.collider.onCollision += p.HandleCollision;
        e.collider.onTrigger += p.HandleTrigger;

        AudioManager.PlaySong("Theme", true, 0.3f);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        SceneManager.Instance.Update(gameTime);

        base.Update(gameTime);
        
    }
    
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();

        SceneManager.Instance.Draw(_spriteBatch);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}