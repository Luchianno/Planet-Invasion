using System.Collections;
using System.Collections.Generic;
using Doozy.Runtime.UIManager.Containers;
using UnityEngine;

public class ChangeCameraPosition : MonoBehaviour
{
    public CameraPositionController.CameraPosition Position;

    [Zenject.Inject]
    CameraPositionController cameraPositionController;

    void Start()
    {
        var view = GetComponent<UIView>();

        // TODO fix
        // view.ShowBehavior.OnStart.Event.AddListener(() =>
        // {
        //     //  Debug.Log($"moving to {Position} ", this.gameObject);
        //     cameraPositionController.ChangePos(Position);
        // });
    }
}
