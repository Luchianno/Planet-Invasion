using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StoryController : IInitializable
{
    HashSet<StoryEntry> activeStoryEntries = new HashSet<StoryEntry>();
    // HashSet<StoryEntry> StoryEntries;

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
            return;
        activeStoryEntries.Add(entry);

        var temp = new TabPanelView.TabPanelViewElement()
        {
            Name = entry.Name,
            Content = entry.Description,
            Image = entry.Image
        };

        view.AddElement(temp);
    }

}
