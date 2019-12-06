using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CardSelectionScreen : MonoBehaviour
{
    public Button Launch;

    [Inject]
    CameraPositionController cameraPositionController;

    [Inject]
    PlanetStateController planetStateController;

    void Start()
    {
        Launch.onClick.AddListener(OnLaunch);
        // I2.Loc.LocalizationManager.GetTermData("").
    }

    void OnLaunch()
    {
        planetStateController.Step();
        // screenManager.ShowPopup<ReportsScreen>("ReportsScreen");
        // screenManager.HideAllAndShow("MapScreen");
    }

}
