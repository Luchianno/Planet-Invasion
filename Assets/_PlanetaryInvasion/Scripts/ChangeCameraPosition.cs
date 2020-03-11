using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

public class ChangeCameraPosition : MonoBehaviour
{
    public CameraPositionController.CameraPosition Position;

    [Zenject.Inject]
    CameraPositionController cameraPositionController;

    void Start()
    {
        var view = GetComponent<UIView>();

        view.ShowBehavior.OnStart.Event.AddListener(() =>
        {
            //  Debug.Log($"moving to {Position} ", this.gameObject);
            cameraPositionController.ChangePos(Position);
        });

        // view.HideBehavior.OnStart.Event.AddListener(() => cameraPositionController.ChangePos(Position));
    }
}
