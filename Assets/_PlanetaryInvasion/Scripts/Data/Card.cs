using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UnityEngine;
using System.Linq;

// partial, because we may add some stuff?..
[CreateAssetMenu(menuName = "PI/Card")]
public partial class Card : ScriptableObject
{
    public bool Active = true;

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

    // TODO rework loading of cards. store path in settings
    public static void LoadAllPlayerCards()
    {
        var list = new List<Card>();
        var cards = Resources.LoadAll<Card>("Player/Cards").Where(x => x.Active);
        if (cards != null)
            list.AddRange(cards);

        list.AddRange(Resources.LoadAll<Card>("Player/Tech").Where(x => x.Active));
        allPlayerCards = new ReadOnlyCollection<Card>(list);
        // Debug.Log($"Loading All Cards. {allPlayerCards.Count} Loaded");
    }

    public static void LoadAllAICards()
    {
        var list = new List<Card>(Resources.LoadAll<Card>("AI/Cards").Where(x => x.Active));
        list.AddRange(Resources.LoadAll<Card>("AI/Tech").Where(x => x.Active));
        allAICards = new ReadOnlyCollection<Card>(list);
        // Debug.Log($"Loading All Cards. {allPlayerCards.Count} Loaded");
    }

    static ReadOnlyCollection<Card> allPlayerCards;
    static ReadOnlyCollection<Card> allAICards;

    // cache stuff
    public static ReadOnlyCollection<Card> AllPlayerCards
    {
        get
        {
            if (allPlayerCards == null)
                LoadAllPlayerCards();
            return allPlayerCards;
        }
    }

    public static ReadOnlyCollection<Card> AllAICards
    {
        get
        {
            if (allPlayerCards == null)
                LoadAllAICards();
            return allPlayerCards;
        }
    }
}
