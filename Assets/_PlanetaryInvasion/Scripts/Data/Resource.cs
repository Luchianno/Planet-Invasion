using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "PI/Resource")]
public class Resource : ScriptableObject
{
    public string Name;

    [TextArea(3, 10)]
    public string Description;
    [PreviewSprite]
    public Sprite Icon;

    static ReadOnlyDictionary<string, Resource> allResources;

    public static ReadOnlyDictionary<string, Resource> AllResources
    {
        get
        {
            if (allResources == null)
                LoadAllResources();
            return allResources;
        }
    }

    public static void LoadAllResources()
    {
        var dict = new Dictionary<string, Resource>();
        foreach (var item in Resources.LoadAll<Resource>("Resources"))
        {
            dict.Add(item.Name, item);
        }
    }
}
