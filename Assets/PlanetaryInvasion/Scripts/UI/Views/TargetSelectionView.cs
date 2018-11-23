using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Zenject;

public class TargetSelectionView : MonoBehaviour
{
    [SerializeField]
    List<Pair> Countries;

    public CountrySelectedEvent OnCountrySelected;
    [SerializeField]
    Button closeButton;

    [SerializeField]
    CanvasGroupController canvasGroup;

    [Inject]
    PlanetState state;

    void Start()
    {
        // TODO check this!
        // foreach (var item in state.AI.CountryStates)
        // {
        //     var index = Countries.FindIndex(x => x.Country.Name == item.Name);
        //     Countries[index].Country = item;
        // }
        closeButton.onClick.AddListener(() => countrySelected(null));
        foreach (var item in Countries)
        {
            item.Button.onClick.AddListener(() => countrySelected(item.Country));
        }
    }

    void countrySelected(CountryState country)
    {
        // canvasGroup.RenderingEnabled = false;
        canvasGroup.FadeOff();
        this.OnCountrySelected.Invoke(country);
    }

    [Serializable]
    public class CountrySelectedEvent : UnityEvent<CountryState> { }

    [Serializable]
    public class Dict : SerializableDictionary<Button, CountryState> { }

    [Serializable]
    public class Pair
    {
        public Button Button;
        public CountryState Country;
    }
}
