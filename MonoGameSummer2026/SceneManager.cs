using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSummer2026;

public class SceneManager : IUpdatable, IDrawable
{
    
    static List <IUpdatable> updatables = new();
    static List <IDrawable> _drawables = new();
    public static List <Collider> colliders = new();
    
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
        if (obj is Collider collider)
        {
            colliders.Add(collider);
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
        
        if (obj is Collider collider)
        {
            colliders.Remove(collider);
        }
    }


    public void Update(GameTime gameTime)
    {
        // prefer for by index to make it by order
        // this will prevent crash in case one of the objects
        // gets deleted while in the loop
        for (int i = 0; i < updatables.Count; i++)
        {
            updatables[i].Update(gameTime);
        }
        
        /*foreach (IUpdatable updatable in updatables)
        {
            updatable.Update(gameTime);
        }*/
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach  (IDrawable drawable in _drawables)
        {
            drawable.Draw(spriteBatch);
        }
    }
}