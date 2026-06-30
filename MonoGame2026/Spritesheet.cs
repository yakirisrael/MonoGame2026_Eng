using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026;

public class Spritesheet
{
    public int rows { get; private set; }
    public int columns { get; private set; }
    public Texture2D texture { get; private set; }
    
    public Spritesheet( Texture2D texture,  int columns = 1, int rows = 1)
    {
        this.rows = rows;
        this.columns = columns;
        this.texture = texture;
    }

    public Rectangle this[int x, int y]
    {
        get
        {
            int width = (int)(texture.Width * (1.0f /columns));
            int height =  (int)(texture.Height * (1.0f /rows));
            
            int pos_x = (int)(texture.Width * ((float)x /columns));
            int pos_y =  (int)(texture.Height * ((float)y /rows));

            return new Rectangle(
                pos_x,
                pos_y,
                width,
                height
            );
        }
    }
}