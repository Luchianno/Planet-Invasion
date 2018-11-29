using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;
using TMPro;

public class TabletView : MonoBehaviour, IUpdateableView, ICardView
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI AP;

    public Color ResourceAvailableColor = Color.green, NoResourcesColor = Color.red;

    public CardClickEvent CardClicked { get; private set; } = new CardClickEvent();

    [Inject]
    PlanetState gameState;

    public Card Card { get; set; }

    public void UpdateView()
    {
        if (Card == null)
        {
            // Debug.LogWarning("No Card assigned");
            return;
        }

        this.Name.text = Card.Name;
        this.AP.text = Card.APCost.ToString();

        Description.text = string.Empty;
        foreach (var item in Card.ResourceRequirements)
        {
            Color color;
            int temp;
            color = gameState.Player.Resources.TryGetValue(item.Key, out temp) && temp >= item.Value ? ResourceAvailableColor : NoResourcesColor;
            Description.text += $"<color={ColorUtility.ToHtmlStringRGBA(color)}>{item.Key}: {item.Value}</color>\n";
        }
    }

    void OnEnable()
    {
        UpdateView();
    }

    public virtual void OnCardClicked()
    {
        CardClicked.Invoke(this);
    }

#if EDITOR
    private void Update()
    {
		
    }
#endif
}
