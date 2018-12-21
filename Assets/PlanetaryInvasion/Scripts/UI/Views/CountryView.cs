using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

public class CountryView : MonoBehaviour, IUpdateableView
{
    public TextMeshProUGUI Label;
    public TextMeshProUGUI Title;
    public CountryState Country;

    // [Inject]
    // PlanetState state;

    public void UpdateView()
    {
        this.Title.text = $"Strength: {Country.Name}";

        this.Label.text = $"Strength: {Country.MilitaryStrength}\n";
        this.Label.text += $"Population: {Country.Population}\n";
        this.Label.text += $"Terror: {Country.Terror}\n";
    }
}
