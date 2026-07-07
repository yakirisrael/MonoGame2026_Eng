using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026;

public class Collider : Sprite
{
    public bool IsTrigger = false;
    
    public Color color;
    public int thickness; 
    
    public Action<Collider, Collider> _onTrigger;
    public Action<Collider, Collider> _onCollision;
        
    Rectangle rect = new Rectangle();
    public Sprite Parent { get; set; }

    public Collider() : base("Pixel")
    {
        
    }
    
    public bool Intersect(Collider other)
    {
        return _destRect.Intersects(other._destRect);
    }

    public void Notify(Collider selfCollider, Collider otherCollider)
    {
        if (IsTrigger || otherCollider.IsTrigger)
            _onTrigger?.Invoke(selfCollider,  otherCollider);
        else 
            _onCollision?.Invoke(selfCollider,  otherCollider);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        
        _destRect = Parent._destRect;

        for (int i = 0; i < SceneManager._colliders.Count; i++)
        {
            Collider collider = SceneManager._colliders[i];
            
            if (collider != this && Intersect(collider))
            {
                Notify(this, collider);
            }
        }
        



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