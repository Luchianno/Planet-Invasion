using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StoryController : IInitializable
{
    HashSet<StoryEntry> activeStoryEntries = new HashSet<StoryEntry>();

    // public IList<StoryEntry> ActiveStoryEntries => activeStoryEntries;

    [Inject(Id = "story")]
    TabPanelView view;

    public void Initialize()
    {
        ScriptableObjectTools<StoryEntry>.LoadAllScriptableObjects("Story"); // TODO move this
    }

    public void AddStory(StoryEntry entry)
    {
        if (activeStoryEntries.Contains(entry)) // TODO change this later?
        {
            Debug.Log("Story entry already exists");
            return;
        }

        activeStoryEntries.Add(entry);

        // view.AddElement(entry);
    }

}
