using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System.Linq;

public class EventLogView : MonoBehaviour, IUpdateableView
{
    [SerializeField]
    TMPro.TextMeshProUGUI label;

    // [SerializeField]
    // Transform parent;

    [Inject]
    PlanetState state;

    int lastCount;

    void Start() => UpdateView();

    public void UpdateView()
    {
        var stories = state.EventLog.Entries;

        label.text = "";
        var entries = state.EventLog.Entries;//state.EventLog.Entries.Where(x => x.Turn == state.Turn);

        var builder = new StringBuilder();
        foreach (var item in entries)
        {
            builder.AppendLine($"{(item.Type.ToString() + ":").PadRight(20)} {item.Text}");
        }
    }
}
