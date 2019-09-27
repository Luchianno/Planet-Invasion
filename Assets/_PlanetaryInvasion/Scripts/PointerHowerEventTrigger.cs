using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerHowerEventTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent PointerEnter;
    public UnityEvent PointerExit;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (PointerEnter != null)
            PointerEnter.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (PointerExit != null)
            PointerExit.Invoke();
    }

}
