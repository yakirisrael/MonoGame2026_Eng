using Microsoft.Xna.Framework;

namespace MonoGame2026;

public interface IUpdatable
{
    void Start();
    void Update(GameTime gameTime);
}