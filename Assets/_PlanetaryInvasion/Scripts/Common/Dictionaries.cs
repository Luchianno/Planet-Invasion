using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

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
            var temp = this[item.Key] + item.Value;
            this[item.Key] = Mathf.Clamp(temp, 0, int.MaxValue);
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