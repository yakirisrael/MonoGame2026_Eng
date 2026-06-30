using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame2026;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _logo;
    private Texture2D _pongAtlas;

    public static Vector2 ScreenCenter;
    
    private Player player = null;
    
    MousePositionText mousePositionText = new MousePositionText();
    
    SpriteFont _fontOswald;

    private SpriteManager _spriteManager;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _spriteManager = new SpriteManager(Content);
        
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
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        _pongAtlas = Content.Load<Texture2D>("Images/pong-atlas");
        
        SpriteManager.AddSprite("pacman", "Images/pacman");
        
        SpriteManager.AddSprite("orangeBird", "Images/Bird1_1", 4,4);
        
        player =  new Player();
        player.Start();
        
        player.Play();
        
        _fontOswald = Content.Load<SpriteFont>("Fonts/OswaldRegular");
        mousePositionText._font = _fontOswald;
        mousePositionText.Start();

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        player.Update(gameTime);
        mousePositionText.Update(gameTime);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkRed);

        
        _spriteBatch.Begin();
        
        player.Draw(_spriteBatch);
        mousePositionText.Draw(_spriteBatch);
        
        int index = 1;
        int columns = 2;
        
        _spriteBatch.Draw(
            _pongAtlas,
            new Vector2(300,300),
            /*DestRect,*/ 
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
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}