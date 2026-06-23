using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026;

public class Sprite : IUpdatable, IDrawable
{
    public Transform _tm = new Transform();
    public Color _color = Color.White;
    public int _sortingOrder = 0;
    public SpriteEffects _spriteEffect = SpriteEffects.None;
    public Texture2D _texture;
    
    public virtual void Update(GameTime gameTime)
    {
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            _texture,
            _tm.Position,
            /*DestRect,*/ 
            null,
            _color,
            MathHelper.ToRadians(_tm.Rotation),
            new Vector2(_texture.Width * 0.5f, _texture.Height * 0.5f),
            _tm.Scale,
            SpriteEffects.None,
            _sortingOrder
        );
    }
}