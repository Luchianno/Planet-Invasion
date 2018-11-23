using System;
using System.Collections.Generic;

[Serializable]
public class AIState : PlayerState
{
    public List<CountryState> CountryStates = new List<CountryState>();

    // GlobalState WorldState; ?
}