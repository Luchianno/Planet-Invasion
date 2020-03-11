using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LaunchButtonView : MonoBehaviour, IUpdateableView
{
    [Inject]
    PlanetState state;

    Button launchButton;

    public void UpdateView()
    {
        // if (launchButton != null)
        launchButton.interactable = state.Player.SelectedCards.Count != 0;
    }

    // Start is called before the first frame update
    void Awake()
    {
        launchButton = GetComponent<Button>();
        launchButton.interactable = false;
    }

}
