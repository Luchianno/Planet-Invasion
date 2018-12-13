using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Zenject;

public class TargetSelectionView : MonoBehaviour
{
    public CountrySelectedEvent OnCountrySelected;

    [SerializeField]
    List<Pair> Countries;

    [SerializeField]
    Button closeButton;

    [SerializeField]
    CanvasGroupController canvasGroup;

    [Inject]
    PlanetState state;


    public CountryState SelectedCountry;
    bool selected;

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
        selected = true;
        SelectedCountry = country;
        this.OnCountrySelected.Invoke(country);
    }

    // TODO remove IEnumerator here
    public IEnumerator OpenAndAwaitForSelection(Action<CountryState> onSelected)
    {
        this.canvasGroup.RenderingEnabled = true;

        selected = false;
        yield return new WaitUntil(() => selected);
        onSelected.Invoke(this.SelectedCountry);
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
