using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ResourcesView : MonoBehaviour, IUpdateableView
{
    [SerializeField]
    Text label;

    [Inject]
    PlanetState gameState;

    void Start()
    {
        UpdateView();
    }

    public void UpdateView()
    {
        StringBuilder builder = new StringBuilder();
        foreach (var item in gameState.Player.Resources)
        {
            builder.AppendLine($"{item.Key.Name} {item.Value}");
        }
        label.text = builder.ToString();
    }
}
