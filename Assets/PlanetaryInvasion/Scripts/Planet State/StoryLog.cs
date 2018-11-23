using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.ObjectModel;

[Serializable]
public class StoryLog
{
    // public ReadOnlyCollection<StoryLogEntry> Stories { get { return stories.AsReadOnly(); } }
    public List<StoryLogEntry> Stories = new List<StoryLogEntry>();

    public class StoryLogEntry
    {
        public string Text;
        public int Turn;
        public StoryLogEntryType Type;
    }

    public enum StoryLogEntryType
    {
        CardResult,
        TechResult,
        RandomNews
    }
}
