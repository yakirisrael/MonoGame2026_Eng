using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026;

public class Enemy : Animation
{
    public Collider collider = new Collider();
    public Enemy() : base("egret")
    {
        _tm.Position = new Vector2(Game1.ScreenCenter.X, (int)Game1.ScreenCenter.Y - 300);
        _tm.Scale = new Vector2(0.3f, 0.3f);  
        
        collider.Parent = this;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        collider.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        collider?.Draw(spriteBatch);
    }
}