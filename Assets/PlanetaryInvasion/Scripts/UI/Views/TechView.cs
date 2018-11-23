using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TechView : MonoBehaviour, IUpdateableView
{
    [Inject]
    PlanetState state;

    [SerializeField]
    Text label;

    StringBuilder builder = new StringBuilder();

    void Start() => UpdateView();

    public void UpdateView()
    {
        builder.Clear();
        foreach (var item in state.Player.Technologies)
        {
            builder.AppendLine(item.Name);
        }
        label.text = builder.ToString();
    }

}
