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

    private Vector2 ScreenCenter;
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

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

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


        float speed = 500;
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
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}