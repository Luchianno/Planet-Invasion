using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TurnCounterView : MonoBehaviour, IUpdateableView
{
    [SerializeField]
    Text label;

    [Inject]
    PlanetState state;

    void Start() => UpdateView();

    public void UpdateView() => label.text = "Turn " + state.Turn.ToString();
}
