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
            return x.Name.CompareTo(y.Name);
        }
    }
}

[Serializable]
public class StringDictionary : SerializableDictionary<string, int> { }

[Serializable]
public class TechDictionary : SerializableDictionary<Tech, int> { }