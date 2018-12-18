using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI.Extensions;
using Zenject;
using System.Linq;

public class AllActionsView : MonoBehaviour, IUpdateableView
{
    public GameObject CardPrefab;

    //    public List<Card> list;

    [SerializeField]
    Transform parent;

    [Inject]
    PlanetStateController stateManager;

    [Inject]
    PlanetState gameState;

    [Inject]
    TabletView.Factory tabletFactory;

    // TODO change to the state change, this should not communicate with other view directly
    [Inject]
    TargetSelectionView targetSelection;

    Dictionary<Card, GameObject> cache = new Dictionary<Card, GameObject>();

    Card selectedCard;

    void Start() => UpdateView();

    void CardClicked(ICardView cardView)
    {
        selectedCard = cardView.Card;
        if (cardView.Card.RequiresTarget)
        {
            StartCoroutine(targetSelection.OpenAndAwaitForSelection(countrySelected));
        }
        else
        {
            stateManager.AddPlayerAction(new SelectedAction() { Country = null, Card = selectedCard });
        }
    }

    void countrySelected(CountryState country)
    {
        if (country == null)
            return;
        stateManager.AddPlayerAction(new SelectedAction() { Country = country, Card = selectedCard });
    }

    public void UpdateView()
    {
        // GODS OF GARBAGE COLLECTION FORGIVE ME
        foreach (var item in cache)
        {
            Destroy(item.Value);
        }
        cache.Clear();

        foreach (var item in Card.AllPlayerCards)
        {
            if (!item.CheckIfUsable(gameState.Player).Allowed
                || gameState.Player.SelectedCards.Exists(x => x.Country == item)) // TODO allowed only one card of same kind?
            {
                continue;
            }

            // Debug.Log(item);

            var cardView = tabletFactory.Create();
            cardView.Init(item, parent);
            cardView.CardClicked.AddListener(this.CardClicked);
            cache[item] = cardView.gameObject;
        }
    }
}
