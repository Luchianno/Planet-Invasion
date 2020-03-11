using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerState
{
    public ResourceDictionary Resources;

    public StringDictionary Vars;

    public List<Tech> Technologies;

    public List<SelectedAction> SelectedCards = new List<SelectedAction>();

    public int CardSlots = 3;
}
