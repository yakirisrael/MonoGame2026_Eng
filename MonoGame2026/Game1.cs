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

    private Vector2 ScreenCenter;
    
    bool isRKey_Pressed = false;
    
    float speed = 0;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
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
        
        _logo =  Content.Load<Texture2D>("Images/logo");
        _pongAtlas = Content.Load<Texture2D>("Images/pong-atlas");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        if (Keyboard.GetState().IsKeyDown(Keys.R) && !isRKey_Pressed)
        {
            // R pressed at this frame
            speed = 500;
        }

        isRKey_Pressed = Keyboard.GetState().IsKeyDown(Keys.R);
        
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkRed);

        
        _spriteBatch.Begin();

        Rectangle DestRect = new Rectangle(
            new Point((int)ScreenCenter.X, (int)ScreenCenter.Y),
            new Point(_logo.Width, _logo.Height));


     
        _spriteBatch.Draw(
            _logo,
            new Vector2(DestRect.X, DestRect.Y),
            /*DestRect,*/ 
            null,
            Color.White,
            MathHelper.ToRadians((float)gameTime.TotalGameTime.TotalSeconds * speed),
            new Vector2(_logo.Width * 0.5f, _logo.Height * 0.5f),
            0.5f,
            SpriteEffects.None,
            0
            );
        
        
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