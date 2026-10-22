using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSummer2026;

public class SpriteManager
{
    static Dictionary<string, Spritesheet> _sprites = new();

    public static ContentManager _content;
    
    public SpriteManager(ContentManager content)
    {
        _content = content;
    }

    public static Spritesheet AddSprite(string spriteName, string fileName, int rows = 1, int columns = 1)
    {
        if (_content == null) return null;

        _sprites[spriteName] = new Spritesheet();
        _sprites[spriteName].texture = _content.Load<Texture2D>(fileName);
        _sprites[spriteName].rows = rows;
        _sprites[spriteName].columns = columns;

        return _sprites[spriteName];
    }

    public static Spritesheet GetSprite(string spriteName)
    {
        if (_sprites.ContainsKey(spriteName))
        {
            return _sprites[spriteName];
        }

        return null;
    }
}