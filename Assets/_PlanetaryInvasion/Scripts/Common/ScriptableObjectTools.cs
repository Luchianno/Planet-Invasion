using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public static class ScriptableObjectTools<T> where T : ScriptableObject
{
    public static void LoadAllScriptableObjects(string path)
    {
        if (cache == null)
            cache = new List<T>();
        else
            cache.Clear();
        cache.AddRange(Resources.LoadAll<T>(path));
    }

    public static void LoadAllScriptableObjects(params string[] paths)
    {
        if (cache == null)
            cache = new List<T>();
        else
            cache.Clear();
        foreach (var item in paths)
        {
            cache.AddRange(Resources.LoadAll<T>(item));
        }
    }

    static List<T> cache;

    public static void ClearCache()
    {
        cache.Clear();
    }

    public static ReadOnlyCollection<T> All
    {
        get
        {
            if (cache == null)
            {
                Debug.LogError("First load objects");
            }
            return cache?.AsReadOnly();
        }
    }
}