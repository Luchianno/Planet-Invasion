using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAction : ScriptableObject
{
    public ActionResultType ResultType { get; set; }
    public string Description { get; set; }
    public PlanetState FinalState { get; set; }
}
