﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraPositionController : MonoBehaviour
{
    [SerializeField]
    new Transform camera;

    [Space]
    [SerializeField]
    Transform missionControl;
    [SerializeField]
    Transform map;
    [SerializeField]
    Transform hangar;


    public float lerpTime = 0.3f;

    public UnityEvent CameraMovementComplete;

    public enum CameraPosition
    {
        MissionControl,
        Map,
        Hangar
    }

    public void ChangePos(CameraPosition pos)
    {
        switch (pos)
        {
            case CameraPosition.MissionControl:
                StartCoroutine(InterpolateLerp(camera.position, missionControl.position));
                break;
            case CameraPosition.Map:
                StartCoroutine(InterpolateLerp(camera.position, map.position));
                break;
            default:
                break;
        }

    }

    // void Interpolate(Vector3 start, Vector3 end)
    // {
    // }

    IEnumerator InterpolateLerp(Vector3 start, Vector3 end)
    {
        float elapsed = 0;
        while (camera.position != end)
        {
            camera.position = Vector3.Lerp(start, end, elapsed / this.lerpTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
        CameraMovementComplete.Invoke();
    }
}
