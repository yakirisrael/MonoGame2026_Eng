using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026;

public class SceneManager : IDrawable, IUpdatable
{
    private static List<IUpdatable> _updatables = new ();
    private static List<IDrawable> _drawables = new();
    public static List<Collider> _colliders = new();

    private static SceneManager instance = null;

    public static SceneManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SceneManager();
            }

            return instance;
        }
    }

    public static T Create<T>() where T : IUpdatable, new()
    {
        T obj = new T();
        
        _updatables.Add(obj);
        
        if (obj is IDrawable drawable)
            _drawables.Add(drawable);
        
        if (obj is Collider collider)
            _colliders.Add(collider);
        
        return obj;
    }

    public static void Remove<T>(T obj) where T : IUpdatable
    {
        // validation if contains
        _updatables.Remove(obj);
        
        if (obj is IDrawable drawable)
            _drawables.Remove(drawable);
        
        if (obj is Collider collider)
            _colliders.Remove(collider);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var drawable in _drawables)
        {
            drawable.Draw(spriteBatch);
        }
        
        foreach (var collider in _colliders)
        {
            collider.Draw(spriteBatch);
        }
    }

    public void Start()
    {
        foreach (var updateable in _updatables)
        {
            updateable.Start();
        }
    }

    public void Update(GameTime gameTime)
    {
        for (int i = 0; i <  _updatables.Count; i++)
        {
            _updatables[i].Update(gameTime);
        }
        
        for (int i = 0; i <  _colliders.Count; i++)
        {
            _colliders[i].Update(gameTime);
        }
    }
}