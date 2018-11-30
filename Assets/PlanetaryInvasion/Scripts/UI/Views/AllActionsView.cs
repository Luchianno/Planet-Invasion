using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;
using Zenject;

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

    Dictionary<Card, GameObject> cache = new Dictionary<Card, GameObject>();

    void Start() => UpdateView();

    void CardClicked(ICardView cardView)
    {
        stateManager.AddPlayerAction(cardView.Card);
    }

    public void UpdateView()
    {
        // GODS OF GARBAGE COLLECTION FORGIVE ME
        foreach (var item in cache)
        {
            Destroy(item.Value);
        }
        cache.Clear();

        foreach (var item in Card.AllCards)
        {
            if (!item.CheckIfUsable(gameState.Player).Allowed
                || gameState.Player.SelectedCards.Contains(item)) // TODO allowed only one card of same kind?
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
