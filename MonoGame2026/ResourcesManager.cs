using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace MonoGame2026;

public class ResourcesManager<T>  where T : class 
{
    private static Dictionary<string, T> _loadedResources = new ();

    private static ContentManager _content;
    
    public ResourcesManager(ContentManager Content)
    {
        _content = Content;
    }

    public static T LoadResource(string name, string fileName)
    {
        if (_content == null)
        {
            Console.WriteLine("Need to initialize content first");
            return null;
        }

        if (!_loadedResources.ContainsKey(name))
        {
            T resourceLoaded = _content.Load<T>(fileName);
            _loadedResources[name] = resourceLoaded;
        }

        return _loadedResources[name];
    }

    public static T GetResource(string name)
    {
        if (_loadedResources.ContainsKey(name)) return _loadedResources[name];
        
        return null;
    }
    
}