using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026;

public class Text : IDrawable, IUpdatable
{
    public Transform _tm = new Transform();
    public Color _color = Color.White;
    public int _sortingOrder = 0;
    public SpriteEffects _spriteEffect = SpriteEffects.None;
    public SpriteFont _font;
    public string _text = string.Empty;
    
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(
            _font,
            _text,
            _tm.Position,
            _color,
            MathHelper.ToRadians(_tm.Rotation),
            (_font.MeasureString(_text) * 0.5f),
            _tm.Scale,
            _spriteEffect,
            _sortingOrder
        );
    }

    public virtual void Start()
    {
        
    }

    public virtual void Update(GameTime gameTime)
    {
        
    }
}