using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "Tech", menuName = "PI/Tech")]
public class Tech : Card
{
    [Space]
    [Header("Tech ")]
    [Space]
    [TextArea(3, 10)]
    public string StudyResult;

    public Sprite ResultImage;

    public override ActionResult Process(TurnState turn, PlanetState state)
    {
        state.Player.Technologies.Add(this);
        return new ActionResult()
        {
            Type = ActionResultType.Success,
            Message = StudyResult,
            MessageType = GameEventLog.StoryLogEntryType.TechResult,
            FinalState = state
        };
    }
}

// public bool DetectLoop()
// {
//     foreach (var item in this.Requirements)
//     {
//         if()
//     }
// }

