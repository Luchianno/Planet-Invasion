using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

// [ExecuteInEditMode]
public class CardView : MonoBehaviour, IUpdateableView
{
    public Text Name;
    public Text Description;
    public Transform RequirementsList;
    public GameObject RequirementPrefab;

    public Text Energy, Metal, Population, AP;

    public Color Good = Color.green, Bad = Color.red, Neutral = Color.black;

    public CardClickEvent CardClicked;// = new CardClickEvent();

    [Inject]
    PlanetState gameState;

    public Card Card;

    public void UpdateView()
    {
        if (Card == null)
        {
            // Debug.LogWarning("No Card assigned");
            return;
        }

        this.Name.text = Card.Name;
        this.Description.text = Card.Name;
        this.AP.text = Card.APCost.ToString();

        // this.Energy.text = value.ResourceRequirements.TryGetValue(;
        // this.Metal.text = value.Name;
        // this.Population.text = value.Name;

        // while (RequirementsList.childCount != 0)
        // {
        //     Destroy(RequirementsList.GetChild(0).gameObject);
        // }
        foreach (var item in Card.TechRequirements)
        {
            var temp = Instantiate<GameObject>(RequirementPrefab, Vector3.zero, Quaternion.identity, RequirementsList);
            var text = temp.GetComponentInChildren<Text>();
            text.text = $"• Requires {item.Name}";
            text.color = gameState.Player.Technologies.Contains(item) ? Color.green : Color.red;
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
