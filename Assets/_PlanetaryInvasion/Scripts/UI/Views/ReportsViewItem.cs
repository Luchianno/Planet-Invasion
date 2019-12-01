using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ReportsViewItem : MonoBehaviour
{
    public event Action<StoryLogEntry> OnClicked;

    public Color CardSuccess;
    public Color CardFail;
    public Color CardNeutral;
    public Color TechColor;
    public Color StoryColor;


    public Image Background;

    public Button Button;

    public TextMeshProUGUI Description;
    public TextMeshProUGUI SuccessType;
    // public TextMeshProUGUI ReportType;

    StoryLogEntry data;

    void Start()
    {
        this.Button.onClick.AddListener(() => OnClicked(data));
    }

    public void Init(StoryLogEntry log)
    {
        data = log;

        // this.ReportType.text = result.MessageType.ToString();



        Button.interactable = false;
        this.SuccessType.text = "";

        switch (log.Type)
        {
            case StoryLogEntryType.CardResult:
                this.Description.text = log.Text;
                this.SuccessType.text = log.SuccessType.ToString() + "!";
                Background.color = log.SuccessType == ActionResultType.Fail ? CardFail : CardSuccess;
                break;

            case StoryLogEntryType.TechResult:
                this.Description.text = $"\"{log.Card.Name}\" - Research Complete"; // (Click for more info)
                Button.interactable = true;
                Background.color = TechColor;
                break;
            case StoryLogEntryType.Story:
                this.Description.text = "Story Entry Unlocked"; // (Click for more info) 
                Button.interactable = true;
                Background.color = StoryColor;
                break;
            case StoryLogEntryType.RandomNews:
                break;
            default:
                break;
        }

    }
}
