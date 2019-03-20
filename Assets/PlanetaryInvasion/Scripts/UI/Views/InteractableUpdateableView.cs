using System;
using UnityEngine;

[RequireComponent(typeof(CanvasGroupController))]
public abstract class InteractableUpdateableView : MonoBehaviour, IUpdateableView
{
    public CanvasGroupController CanvasGroup { get; protected set; }

    protected virtual void Awake()
    {
        this.CanvasGroup = GetComponent<CanvasGroupController>();
    }

    public abstract void UpdateView();
}