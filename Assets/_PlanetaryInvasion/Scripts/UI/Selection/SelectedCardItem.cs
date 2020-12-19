using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SelectedCardItem : MonoBehaviour, IUpdateableView, ICardView
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI PopupDescription;
    public Image Icon;

    public Color ResourceAvailableColor = Color.green, NoResourcesColor = Color.red;

    public CardClickEvent CardClicked { get; private set; } = new CardClickEvent();

    PlanetState gameState;

    public Card Card { get; set; }

    [Inject]
    public void Construct(PlanetState state)
    {
        gameState = state;
    }

    public void Init(Card card, Transform parent)
    {
        this.Card = card;
        this.transform.SetParent(parent, false);
        UpdateView();
    }

    public class Factory : PlaceholderFactory<TabletView>
    {
    }

    public void UpdateView()
    {
        if (Card == null)
        {
            // Debug.LogWarning("No Card assigned");
            return;
        }

        this.Name.text = Card.Name;
        this.Icon.sprite = Card.Icon;

        Description.text = "";
        PopupDescription.text = string.IsNullOrEmpty(this.Card.Description) ? "" : Card.Description + "\n";
        // foreach (var item in Card.ResourceRequirements)
        // {
        //     Color color;
        //     int temp;
        //     color = gameState.Player.Resources.TryGetValue(item.Key, out temp) && temp >= item.Value ? ResourceAvailableColor : NoResourcesColor;
        //     Description.text += $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{item.Key.Name}: {item.Value}</color>\n";
        // }

        // if (Description.text == "")
        // {
        //     Description.text = $"<color=#{ColorUtility.ToHtmlStringRGBA(ResourceAvailableColor)}>FREE</color>";
        // }
    }

    void OnEnable()
    {
        UpdateView();
    }

    public virtual void OnCardClicked()
    {
        CardClicked.Invoke(this);
    }

}
