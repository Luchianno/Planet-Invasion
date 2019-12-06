using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Doozy.Engine.UI;

[RequireComponent(typeof(Button))]
public class OpenPopupOnClick : MonoBehaviour
{
    Button button;

    public string PopupName;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        var popup = UIPopup.GetPopup(PopupName);

        popup.Show();
    }

}
