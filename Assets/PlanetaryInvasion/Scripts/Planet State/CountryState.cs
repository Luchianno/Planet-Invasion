using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "PI/Country State")]
public class CountryState : ScriptableObject
{
    public string Name;

    [TextArea(3, 10)]
    public string Description;

    public float Population = 10f;
    public int MilitaryStrength = 10;

    [Range(0, 10)]
    public int Friendliness;
    [Range(0, 10)]
    public int Terror;

    public int Money = 10;

    public int MoneyPerMonth = 1;

    public float PopulationPerMonth = 0.1f;
}
