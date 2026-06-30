using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026;

public class SpriteManager
{
    private static Dictionary<string, Spritesheet> _spritesheets = new Dictionary<string, Spritesheet>();

    private static ContentManager _content;
    
    public SpriteManager(ContentManager Content)
    {
        _content = Content;
    }

    public static void AddSprite(string name, string fileName, int columns = 1, int height = 1)
    {
        Texture2D texture = _content.Load<Texture2D>(fileName);
        _spritesheets[name]  = new Spritesheet(texture, columns, columns);
    }

    public static Spritesheet GetSprite(string name)
    {
        if (_spritesheets.ContainsKey(name))
            return _spritesheets[name];
        
        return null;
    }
    
}