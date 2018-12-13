using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UnityEngine;

// partial, because we may add some stuff?..
[CreateAssetMenu(menuName = "PI/Card")]
public partial class Card : ScriptableObject
{
    public string Name;

    [TextArea(3, 10)]
    public string Description;

    [Header("Needs a target country")]
    public bool RequiresTarget = false;

    [Header("1 Means Instant")]
    [Range(1, 10)]
    public int TurnsRequired = 1;

    [Range(1, 10)]
    public int APCost = 1;

    public ResourceDictionary ResourceRequirements;

    public StringDictionary VarRequirements;

    public List<Tech> TechRequirements;

    public virtual ActionResult PreProcess(TurnState turn, PlanetState state)
    {
        return new ActionResult { FinalState = state };
    }

    public virtual ActionResult Process(TurnState turn, PlanetState state)
    {
        //Debug.LogWarning("Default Action Result not Redefined, check it");
        return new ActionResult { FinalState = state };
    }

    public virtual ActionResult AfterProcess(TurnState turn, PlanetState state)
    {
        return new ActionResult { FinalState = state };
    }

    public virtual ActionAllowedResult CheckIfUsable(PlayerState state)
    {
        var result = new ActionAllowedResult() { Allowed = true, Message = "" };

        StringBuilder builder = new StringBuilder();

        foreach (var item in this.ResourceRequirements)
        {
            int res;
            if (state.Resources.TryGetValue(item.Key, out res) || res >= item.Value)
            {
            }
            else
            {
                result.Allowed = false;
                builder.AppendLine($"Not Enough {item.Key}");
            }
        }

        foreach (var item in this.TechRequirements)
        {
            if (!state.Technologies.Contains(item))
            {
                result.Allowed = false;
                builder.AppendLine($"\"{item}\" not researched");
            }
        }

        foreach (var item in this.VarRequirements)
        {
            int varValue;
            if (!state.Vars.TryGetValue(item.Key, out varValue))
            {
                result.Allowed = false;
                builder.AppendLine($"\"{item.Key}\" Var not set");
            }
        }

        result.Message = builder.ToString();

        return result;
    }

    public static void LoadAllCards()
    {
        var list = new List<Card>(Resources.LoadAll<Card>("Cards"));
        list.AddRange(Resources.LoadAll<Card>("Tech"));
        allCards = new ReadOnlyCollection<Card>(list);
        Debug.Log($"Loading All Cards. {allCards.Count} Loaded");
        // foreach (var item in allCards)
        // {
        //     Debug.Log(item);
        // }
    }
    static ReadOnlyCollection<Card> allCards;

    // cache stuff
    public static ReadOnlyCollection<Card> AllCards
    {
        get
        {
            if (allCards == null)
                LoadAllCards();
            return allCards;
        }
    }
}
