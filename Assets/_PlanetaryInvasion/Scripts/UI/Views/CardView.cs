using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;
using TMPro;

// [ExecuteInEditMode]
public class CardView : MonoBehaviour, IUpdateableView, ICardView
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public Transform RequirementsList;
    public GameObject RequirementPrefab;

    public TextMeshProUGUI Energy, Metal, Population, AP;

    public Color Good = Color.green, Bad = Color.red;//, Neutral = Color.black;

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
        // this.Description.text = Card.Name;
        this.AP.text = Card.APCost.ToString();

        // this.Energy.text = value.ResourceRequirements.TryGetValue(;
        // this.Metal.text = value.Name;
        // this.Population.text = value.Name;

        // while (RequirementsList.childCount != 0)
        // {
        //     Destroy(RequirementsList.GetChild(0).gameObject);
        // }
        // foreach (var item in Card.TechRequirements)
        // {
        //     var temp = Instantiate<GameObject>(RequirementPrefab, Vector3.zero, Quaternion.identity, RequirementsList);
        //     var text = temp.GetComponentInChildren<Text>();
        //     text.text = $"• Requires {item.Name}";
        //     text.color = gameState.Player.Technologies.Contains(item) ? Color.green : Color.red;
        // }

        Description.text = string.Empty;
        foreach (var item in Card.ResourceRequirements)
        {
            Color color;
            int temp;
            color = gameState.Player.Resources.TryGetValue(item.Key, out temp) && temp >= item.Value ? Good : Bad;
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
