using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.ObjectModel;
using System.Linq;

[Serializable]
public class GameEventLog
{
    // public ReadOnlyCollection<StoryLogEntry> Stories { get { return stories.AsReadOnly(); } }
    public List<StoryLogEntry> Entries = new List<StoryLogEntry>();

    public IEnumerable<StoryLogEntry> FromTurn(int turn)
    {
        return Entries.Where(x => x.Turn == turn);
    }
}
