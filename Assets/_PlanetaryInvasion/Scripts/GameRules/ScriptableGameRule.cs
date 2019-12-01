using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableGameRule : ScriptableObject, IGameRule
{
    public string Title;
    
    [TextArea(3, 10)]
    public string Description;
    
    public Sprite Background;

    public abstract bool Check(PlanetState state);
}
