using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026;

public class Collider : Sprite
{
    public bool IsTrigger = false;
    
    public Color color;
    public int thickness; 
    
    Rectangle rect = new Rectangle();
    public Sprite Parent { get; set; }

    public Collider() : base("Pixel")
    {
        
    }
    
    public bool Intersect(Collider other)
    {
        return false;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        
        _destRect = Parent._destRect;
        
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
#if DEBUG
        // draw outline bounds
        
        color = Color.Green;
        thickness = 5;
        
        spriteBatch.Draw(
            _texture,
            new Rectangle(_destRect.X, _destRect.Y, _destRect.Width, thickness), // top
            color);

        spriteBatch.Draw(
            _texture,
            new Rectangle(_destRect.X, _destRect.Y, thickness, _destRect.Height), // left
            color);

        spriteBatch.Draw(
            _texture,
            new Rectangle(_destRect.X + _destRect.Width - thickness, _destRect.Y, thickness, _destRect.Height), // right
            color);

        spriteBatch.Draw(
            _texture,
            new Rectangle(_destRect.X, _destRect.Y + _destRect.Height - thickness, _destRect.Width, thickness), // bottom
            color);
        
#endif
    }
}