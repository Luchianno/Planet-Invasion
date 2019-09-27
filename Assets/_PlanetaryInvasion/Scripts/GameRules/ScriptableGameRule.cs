using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableGameRule : ScriptableObject, IGameRule
{
    public abstract bool Check(PlanetState state);
}
