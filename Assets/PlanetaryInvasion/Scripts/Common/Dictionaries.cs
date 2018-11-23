using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class ResourceDictionary : SerializableDictionary<Resource, int> { }

[Serializable]
public class StringDictionary : SerializableDictionary<string, int> { }

[Serializable]
public class TechDictionary : SerializableDictionary<Tech, int> { }