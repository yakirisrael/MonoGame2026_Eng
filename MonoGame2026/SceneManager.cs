using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame2026;

public class SceneManager : IDrawable, IUpdatable
{
    private static List<IUpdatable> _updatables = new ();
    private static List<IDrawable> _drawables = new();

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
        
        return obj;
    }

    public static void Remove<T>(T obj) where T : IUpdatable
    {
        // validation if contains
        _updatables.Remove(obj);
        
        if (obj is IDrawable drawable)
            _drawables.Remove(drawable);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var drawable in _drawables)
        {
            drawable.Draw(spriteBatch);
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
        foreach (var updateable in _updatables)
        {
            updateable.Update(gameTime);
        }
    }
}