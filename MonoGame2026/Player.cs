using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame2026;

public class Player : Sprite
{
    bool isRKey_Pressed = false;
    
    float speed = 0;

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (Keyboard.GetState().IsKeyDown(Keys.R) && !isRKey_Pressed)
        {
            // R pressed at this frame
            speed = 500;
        }

        isRKey_Pressed = Keyboard.GetState().IsKeyDown(Keys.R);
        
        Rectangle DestRect = new Rectangle(
            new Point((int)Game1.ScreenCenter.X, (int)Game1.ScreenCenter.Y),
            new Point(_texture.Width, _texture.Height));
        
        _tm.Position = new Vector2(DestRect.X, DestRect.Y);
        _tm.Rotation = (float)gameTime.TotalGameTime.TotalSeconds * speed;

        //To player logic
    }
}