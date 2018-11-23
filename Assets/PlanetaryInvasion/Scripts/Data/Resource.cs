using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "PI/Resource")]
public class Resource : ScriptableObject
{
    public string Name;
    
    [TextArea(3, 10)]
    public string Description;
    public Sprite Icon;
}
