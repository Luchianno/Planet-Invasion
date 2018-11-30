using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SelectedActionsView : MonoBehaviour, IUpdateableView
{
    public Text Label;

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

    Dictionary<Card, GameObject> cache = new Dictionary<Card, GameObject>();

    List<GameObject> placeholders = new List<GameObject>();

    private void CardClicked(ICardView cardView)
    {
        stateManager.RemovePlayerAction(cardView.Card);
    }

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
            AddCard(item);
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
        var cardView = tabletFactory.Create();
        cardView.Init(card, parent);
        // get outline and change color
        cardView.UpdateView();
        cardView.CardClicked.AddListener(this.CardClicked);
        cache[card] = cardView.gameObject;
    }
}
