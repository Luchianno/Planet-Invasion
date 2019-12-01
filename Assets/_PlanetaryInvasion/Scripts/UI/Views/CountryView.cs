using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

public class CountryView : MonoBehaviour, IUpdateableView
{
    public string CountryName;

    [SerializeField]
    protected TextMeshProUGUI Label;
    [SerializeField]
    protected TextMeshProUGUI Title;
    [SerializeField]
    protected TextMeshProUGUI Description;

    [Inject]
    PlanetState state;

    public void UpdateView()
    {
        var country = state.AI.CountryStates.Find(x => x.Name == CountryName);

        if (country == null)
        {
            Debug.LogError("Set Country Name", this.gameObject);
            Debug.Log(CountryName);
            return;
        }

        this.Title.text = $"{country.Name}";

        this.Label.text = $"Strength: {country.MilitaryStrength}\n";
        this.Label.text += $"Population: {country.Population}\n";
        this.Label.text += $"Terror: {country.Terror}\n";
        this.Description.text = country.Description;
    }
}
