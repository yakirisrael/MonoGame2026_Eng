using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame2026;

public class Player : Animation
{
    bool isRKey_Pressed = false;
    
    float speed = 0;
    
    float MovementSpeed = 300;
    
    public Collider collider = null;
    
    Vector2 prevPos = Vector2.Zero;
    
    bool isColliding = false;

    public Player() : base( "orangeBird")
    {
        collider = SceneManager.Create<Collider>();
        collider.Parent = this;
        collider.IsTrigger =  true;
    }
    
    public override void Start()
    {
        //   Rectangle DestRect = new Rectangle(
        //      new Point((int)Game1.ScreenCenter.X, (int)Game1.ScreenCenter.Y),
        //      new Point(_texture.Width, _texture.Height));
        
        base.Start();
        
        _tm.Position = new Vector2(Game1.ScreenCenter.X, (int)Game1.ScreenCenter.Y);
        _tm.Scale = new Vector2(0.3f, 0.3f);  
        
        prevPos = _tm.Position;
    }


    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        
        if (isColliding)
        {
            _tm.Position = prevPos;
            isColliding =  false;
        }
        prevPos = _tm.Position;
        
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        if (Keyboard.GetState().IsKeyDown(Keys.R) && !isRKey_Pressed)
        {
            // R pressed at this frame
            speed = 500;
            _tm.Rotation = (float)gameTime.TotalGameTime.TotalSeconds * speed;
        }
        

        isRKey_Pressed = Keyboard.GetState().IsKeyDown(Keys.R);
        
        if (Keyboard.GetState().IsKeyDown(Keys.D))
        {
            _spriteEffect = SpriteEffects.FlipHorizontally;
            _tm.Position += new Vector2(MovementSpeed * dt , 0);
        }
        if (Keyboard.GetState().IsKeyDown(Keys.A))
        {
            _spriteEffect = SpriteEffects.None;
            _tm.Position += new Vector2(-MovementSpeed * dt , 0);
        }
        if (Keyboard.GetState().IsKeyDown(Keys.S))
        {
            _tm.Position += new Vector2(0 , MovementSpeed * dt);
        }
        if (Keyboard.GetState().IsKeyDown(Keys.W))
        {
            _tm.Position += new Vector2(0 , -MovementSpeed * dt);
        }

        if (Keyboard.GetState().IsKeyDown(Keys.NumPad1))
        {
            ChangeSprite("duck");
        }


        //To player logic
    }

    public void OnTriggerEnter(Collider self, Collider other)
    {
        Console.WriteLine("OnTriggerEnter:" + other + " with " + self);
        
        SceneManager.Remove(other);
        SceneManager.Remove(other.Parent);
    }
    
    public void OnCollisionEnter(Collider self, Collider other)
    {
        isColliding = true;
        Console.WriteLine("OnCollisionEnter:" + other.Parent + " with " + self.Parent);
        

    }
}