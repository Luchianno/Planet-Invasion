using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SelectedActionsView : MonoBehaviour, IUpdateableView
{
    public GameObject CardPrefab;
    public GameObject PlaceHolderPrefab;


    [SerializeField]
    Transform parent;

    [Inject]
    PlanetStateController stateManager;

    [Inject]
    PlanetState state;

    [Inject]
    TabletView.Factory tabletFactory;

    // TODO change to the state change, this should not communicate with other view directly
    [Inject]
    TargetSelectionView targetSelection;

    [Inject]
    GameSettings settings;

    Dictionary<Card, GameObject> cache = new Dictionary<Card, GameObject>();
    Dictionary<Card, CountryState> SelectedParams = new Dictionary<Card, CountryState>(); // TODO it's bad approach

    List<GameObject> placeholders = new List<GameObject>();

    public void UpdateView()
    {
        foreach (var item in cache)
        {
            Destroy(item.Value);
        }
        cache.Clear();

        foreach (var item in placeholders)
        {
            Destroy(item);
        }
        placeholders.Clear();

        foreach (var item in stateManager.PlayerSelectedCards)
        {
            AddCard(item.Card);
        }

        if (stateManager.PlayerSelectedCards.Count < state.Player.CardSlots)
        {
            for (int i = 0; i < state.Player.CardSlots - stateManager.PlayerSelectedCards.Count; i++)
            {
                var temp = Instantiate(PlaceHolderPrefab, Vector3.zero, Quaternion.identity, parent);
                placeholders.Add(temp);
            }
        }
    }

    public void AddCard(Card card)
    {
        if (SelectedParams.Count >= settings.CardSelectionLimit)
            return;
            
        var cardView = tabletFactory.Create();
        cardView.Init(card, parent);
        // get outline and change color
        cardView.UpdateView();
        cardView.CardClicked.AddListener(this.CardClicked);
        cache[card] = cardView.gameObject;
    }

    void Start()
    {
        foreach (Transform item in parent)
        {
            if (parent != item)
                Destroy(item.gameObject);
        }

        for (int i = 0; i < settings.CardSelectionLimit; i++)
        {
            var temp = Instantiate(PlaceHolderPrefab, Vector3.zero, Quaternion.identity, parent);
            placeholders.Add(temp);
        }
    }

    void CardClicked(ICardView cardView)
    {
        if (cardView.Card.RequiresTarget)
        {
            targetSelection.GetComponent<CanvasGroupController>().RenderingEnabled = true;
            this.targetSelection.OnCountrySelected.AddListener(x => SelectedParams[cardView.Card] = x);
        }
        stateManager.RemovePlayerAction(cardView.Card);
    }

}
