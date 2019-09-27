using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AssociateWithBackKey : MonoBehaviour
{
    Button butt;

    void Start()
    {
        butt = GetComponent<Button>();
    }

    void Update()
    {
        if (butt.interactable && Input.GetMouseButtonUp(1))
        {
            butt.onClick.Invoke();
        }
    }
}
