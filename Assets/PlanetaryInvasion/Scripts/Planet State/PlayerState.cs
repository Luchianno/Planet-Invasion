using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerState
{
    public ResourceDictionary Resources { get; private set; } = new ResourceDictionary();

    public StringDictionary Vars { get; private set; } = new StringDictionary();

    public List<Tech> Technologies { get; private set; } = new List<Tech>();

    public List<Card> SelectedCards { get; private set; } = new List<Card>();

    public int CardSlots = 3;
}
