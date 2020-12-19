using System.Collections;
using System.Collections.Generic;
using Doozy.Engine.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CardSelectionScreen : MonoBehaviour
{
    public Button Launch;

    [Inject]
    PlanetStateController planetStateController;

    [Inject]
    AIPlayer AIPlayer;

    void Start()
    {
        Launch.onClick.AddListener(OnLaunch);
        // I2.Loc.LocalizationManager.GetTermData("").
    }

    void OnLaunch()
    {
        AIPlayer.Think();
        planetStateController.Step();
        
        var popup = UIPopup.GetPopup("Reports");
        popup.Show();
        // screenManager.ShowPopup<ReportsScreen>("ReportsScreen");
        // screenManager.HideAllAndShow("MapScreen");
    }

}
