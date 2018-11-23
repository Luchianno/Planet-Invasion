using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UnityEngine;

// partial, because we may add some stuff?..
[CreateAssetMenu(menuName = "PI/Story Entry")]
public class StoryEntry : ScriptableObject
{
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
}
