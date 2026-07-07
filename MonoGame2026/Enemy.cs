using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026;

public class Enemy : Animation
{
    public Collider collider = null;
    public Enemy() : base("egret")
    {
        collider = SceneManager.Create<Collider>();
        collider.Parent = this;
        
        _tm.Position = new Vector2(Game1.ScreenCenter.X, (int)Game1.ScreenCenter.Y - 300);
        _tm.Scale = new Vector2(0.3f, 0.3f);  
        

    }
}