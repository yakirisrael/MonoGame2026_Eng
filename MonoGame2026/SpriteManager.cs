using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026;

public class SpriteManager
{
    private static Dictionary<string, Spritesheet> _spritesheets = new ();
    public static void AddSprite(string name, string fileName, int columns = 1, int height = 1)
    {
       // load the texture from resources manager
        Texture2D texture = ResourcesManager<Texture2D>.LoadResource(name, fileName);
        
        if (texture != null)
            _spritesheets[name] = new Spritesheet(texture, columns, columns);
    }

    public static Spritesheet GetSprite(string name)
    {
        if (_spritesheets.ContainsKey(name)) return _spritesheets[name];

        return null;
    }
}