using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryLogEntry
{
    // can be null
    public Card Card;
    public string Text;
    public int Turn;

    public bool IsPlayerAction;

    public ActionResultType SuccessType;
    
    public StoryLogEntryType Type;
}
