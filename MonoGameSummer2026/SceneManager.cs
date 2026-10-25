using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSummer2026;

public class SceneManager : IUpdatable, IDrawable
{
    
    static List <IUpdatable> updatables = new();
    static List <IDrawable> _drawables = new();
    
    private static SceneManager instance;
    
    public static SceneManager Instance
    {
        get
        {
            if (instance == null)
                instance = new SceneManager();
            
            return instance;
        }
    }

    public static T Create<T>() where T : IDrawable, new()
    {
        T obj = new T();
        Add(obj);
        return obj;
    }

    public static void Add<T>(T obj) where T : IDrawable
    {
        if (obj is IUpdatable updatable)
        {
            updatables.Add(updatable);
        }

        if (obj is IDrawable drawable)
        {
            _drawables.Add(obj);
        }
    }
    
    public static void Remove<T>(T obj) where T : IDrawable
    {
        if (obj is IUpdatable updatable)
        {
            updatables.Remove(updatable);
        }

        if (obj is IDrawable drawable)
        {
            _drawables.Remove(obj);
        }
    }


    public void Update(GameTime gameTime)
    {
        foreach (IUpdatable updatable in updatables)
        {
            updatable.Update(gameTime);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach  (IDrawable drawable in _drawables)
        {
            drawable.Draw(spriteBatch);
        }
    }
}