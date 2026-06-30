using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame2026;

public class MousePositionText : Text
{
    public override void Start()
    {
        base.Start();

        _tm.Position = new Vector2(Game1.ScreenCenter.X, 50.0f);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        _text = Mouse.GetState().Position.ToString();
    }
}