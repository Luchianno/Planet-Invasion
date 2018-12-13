using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class ResourceDictionary : SerializableSortedDictionary<Resource, int>
{
    public ResourceDictionary() : base(new ResourceComparer()) { }

    class ResourceComparer : IComparer<Resource>
    {
        public int Compare(Resource x, Resource y)
        {
            // Debug.Log("${x.Name.CompareTo(y)} {x} + {y}");
            return x?.Name?.CompareTo(y?.Name) ?? 0;
        }
    }

    public void AddResources(ResourceDictionary amount)
    {
        foreach (var item in amount)
        {
            if (!this.ContainsKey(item.Key))
            {
                this.Add(item.Key, 0);
            }
            this[item.Key] += item.Value;
        }
    }

    public bool RemoveResources(ResourceDictionary amount)
    {
        foreach (var item in amount)
        {
            int resource;
            if (!(this.TryGetValue(item.Key, out resource) && resource >= item.Value))
            {
                return false;
            }
        }

        foreach (var item in amount)
        {
            int resource;
            if (this.TryGetValue(item.Key, out resource) && resource >= item.Value)
            {
                this[item.Key] -= item.Value;
            }
        }

        return true;
    }
}

[Serializable]
public class StringDictionary : SerializableDictionary<string, int> { }

[Serializable]
public class TechDictionary : SerializableDictionary<Tech, int> { }