using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UnityEngine;

// partial, because we may add some stuff?..
[CreateAssetMenu(menuName = "PI/Story Entry")]
public class StoryEntry : ScriptableObject
{
    public bool Active = true;

    public string Name;

    [TextArea(3, 10)]
    public string Description;

    public Sprite Image;

    public StringDictionary VarRequirements;

    public virtual bool ShouldActivate(PlayerState state)
    {
        // Debug.Log("sdd");
        bool result = true;
        foreach (var item in this.VarRequirements)
        {
            int varValue;
            if (!state.Vars.TryGetValue(item.Key, out varValue))
            {
                result = false;
            }
            else
            {
                if (varValue != item.Value)
                    result = false;
            }
        }
        return result;
    }

    public static ReadOnlyCollection<StoryEntry> AllStories
    {
        get
        {
            if (allStories == null)
                allStories = LoadAllAICards();

            return allStories.AsReadOnly();
        }
    }

    public static List<StoryEntry> UnlockedStories(PlanetState state)
    {
        return AllStories.Where(x => x.ShouldActivate(state.Player)).ToList();
    }


    static List<StoryEntry> allStories;

    static List<StoryEntry> LoadAllAICards()
    {
        return Resources.LoadAll<StoryEntry>("Story")?.Where(x => x.Active).ToList();
    }
}
