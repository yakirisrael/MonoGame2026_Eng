using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MonoGame2026;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _logo;
    private Texture2D _pongAtlas;

    public static Vector2 ScreenCenter;
    
    private Player player = null;
    private Enemy enemyEgret = null;
    
    MousePositionText mousePositionText = new MousePositionText();
    
    SpriteFont _fontOswald;

    private SpriteManager _spriteManager;

    #region resourcesManagers
    
    private ResourcesManager<Texture2D> _textureManager;
    private ResourcesManager<Song> _songManager;
    private ResourcesManager<SoundEffect> _soundEffectManager;

    #endregion
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        
        _textureManager = new ResourcesManager<Texture2D>(Content);
        _songManager = new ResourcesManager<Song>(Content);
        _soundEffectManager = new ResourcesManager<SoundEffect>(Content);
        
        _spriteManager = new SpriteManager();
        
        
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.IsFullScreen = true;
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;

        ScreenCenter = new Vector2(_graphics.PreferredBackBufferWidth * 0.5f,
                                   _graphics.PreferredBackBufferHeight * 0.5f);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        AudioManager.AddSong("theme", "Audio/Music/theme");
        AudioManager.AddSoundEffect("bounce", "Audio/SFX/bounce");
        AudioManager.AddSoundEffect("collect", "Audio/SFX/collect");
        
        
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        _pongAtlas = Content.Load<Texture2D>("Images/pong-atlas");
        
        SpriteManager.AddSprite("pacman", "Images/pacman");
        
        SpriteManager.AddSprite("orangeBird", "Images/Bird1_1", 4,4);
        SpriteManager.AddSprite("duck", "Images/Bird2 Duck_1", 4,4);
        SpriteManager.AddSprite("egret", "Images/Bird3_Egret4", 4,4);
        SpriteManager.AddSprite("Pixel", "Images/pixel");
        
        player = SceneManager.Create<Player>();
        player.Play();
        
        enemyEgret = SceneManager.Create<Enemy>();
        enemyEgret.Play();
        
        player.collider._onCollision += player.OnCollisionEnter;
        player.collider._onTrigger += player.OnTriggerEnter;
        
        _fontOswald = Content.Load<SpriteFont>("Fonts/OswaldRegular");
        mousePositionText._font = _fontOswald;

        AudioManager.PlaySong("theme");
        
        SceneManager.Instance.Start();

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        SceneManager.Instance.Update(gameTime);
       
    //    mousePositionText.Update(gameTime);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkRed);

        
        _spriteBatch.Begin();
        
        SceneManager.Instance.Draw(_spriteBatch);
        
        mousePositionText.Draw(_spriteBatch);
        
        /*int index = 1;
        int columns = 2;
        
        _spriteBatch.Draw(
            _pongAtlas,
            new Vector2(300,300),
            /*DestRect, 
            new Rectangle(
                new Point((int)(index * _pongAtlas.Width / columns),0), 
                new Point((int)(_pongAtlas.Width / columns), 
                          (int)(_pongAtlas.Height))
                ),
            Color.White,
            MathHelper.ToRadians(0),
            new Vector2(_pongAtlas.Width * 0.5f, _pongAtlas.Height * 0.5f),
            new Vector2(1.0f, 1.0f),
            SpriteEffects.None,
            0
        );
        */
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}