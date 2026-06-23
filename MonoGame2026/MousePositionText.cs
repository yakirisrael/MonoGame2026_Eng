using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame2026;

public class MousePositionText : Text
{
    public override void Start()
    {
        base.Start();

        _tm.Position = Game1.ScreenCenter;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        _text = Mouse.GetState().Position.ToString();
    }
}