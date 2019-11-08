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

        state.EventLog.Entries.Add(new StoryLogEntry()
        {
            Card = this,
            SuccessType = ActionResultType.Undefined,
            Turn = state.Turn,
            Text = this.StudyResult,
            Type = StoryLogEntryType.TechResult
        });

        return new ActionResult()
        {
            Type = ActionResultType.Success,
            Message = StudyResult,
            MessageType = StoryLogEntryType.TechResult,
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

