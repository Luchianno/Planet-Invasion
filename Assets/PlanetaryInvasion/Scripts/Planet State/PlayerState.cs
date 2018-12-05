using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerState
{
    public ResourceDictionary Resources = new ResourceDictionary();

    public StringDictionary Vars = new StringDictionary();

    public List<Tech> Technologies = new List<Tech>();

    public List<Card> SelectedCards = new List<Card>();

    public int CardSlots = 3;
}