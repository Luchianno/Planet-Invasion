using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EventLogView : MonoBehaviour, IUpdateableView
{
    [SerializeField]
    Text label;

    [SerializeField]
    Transform parent;

    [Inject]
    PlanetState state;

    int lastCount;

    void Start() => UpdateView();

    public void UpdateView()
    {
        var stories = state.Story.Stories;
        
        if (lastCount != stories.Count)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = lastCount; i < stories.Count; i++)
            {
                var entry = stories[lastCount];
                builder.AppendLine($"{(entry.Type.ToString() + ":").PadRight(20)} {entry.Text}");
            }
            label.text += builder.ToString();
        }
    }
}
