using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(StringDictionary))]
[CustomPropertyDrawer(typeof(ResourceDictionary))]
[CustomPropertyDrawer(typeof(TechDictionary))]
public class AnyDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer { }
