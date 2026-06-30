using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026;

public class Sprite : IUpdatable, IDrawable
{
    public Transform _tm = new Transform();
    public Color _color = Color.White;
    public int _sortingOrder = 0;
    public SpriteEffects _spriteEffect = SpriteEffects.None;
    
    public Spritesheet spritesheet;
    
    private Texture2D _texture;

    protected Rectangle? _sourceRect = null;
    private Rectangle _destRect;
    
    private Vector2 _origin = Vector2.Zero;


    public Sprite(string spriteName)
    {
        spritesheet =  SpriteManager.GetSprite(spriteName);
        _texture = spritesheet.texture;
    }

    public virtual void Start()
    {
        
    }

    private Rectangle GetDestRect(Rectangle? sourceRect)
    {
        if (sourceRect == null) return new Rectangle();
        
        int width = (int)(sourceRect.Value.Width * _tm.Scale.X);
        int height = (int)(sourceRect.Value.Height * _tm.Scale.Y);
        
        int pos_x = (int)(_tm.Position.X - (_origin.X * _tm.Scale.X));
        int pos_y = (int)(_tm.Position.Y - (_origin.Y * _tm.Scale.Y));

        return new Rectangle(
            pos_x,
            pos_y,
            width,
            height
        );
    }

    public virtual void Update(GameTime gameTime)
    {
        // origin calculation must happened AFTER the source being update
        // which is occur in the Animation.update()
       _origin = new Vector2(_sourceRect.Value.Width * 0.5f, _sourceRect.Value.Height * 0.5f);
       _destRect = GetDestRect(_sourceRect);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            _texture,
            _tm.Position, 
            _sourceRect,
            _color,
            MathHelper.ToRadians(_tm.Rotation),
            _origin,
            _tm.Scale,
            _spriteEffect,
            _sortingOrder
        );
    }
}