using System;
using System.Collections.Generic;

[Serializable]
public class AIState : PlayerState
{
    [NonSerialized]
    public List<CountryState> CountryStates = new List<CountryState>();

    // GlobalState WorldState; ?
}