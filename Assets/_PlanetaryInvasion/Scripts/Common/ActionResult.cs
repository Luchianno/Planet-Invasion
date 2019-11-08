using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ActionResult
{
    public Card Action { get; set; }

    public ActionResultType Type { get; set; }
    public string Message { get; set; }
    public PlanetState FinalState { get; set; }

    public StoryLogEntryType MessageType { get; set; }
}

public enum ActionResultType
{
    Undefined,
    Success,
    Fail
}