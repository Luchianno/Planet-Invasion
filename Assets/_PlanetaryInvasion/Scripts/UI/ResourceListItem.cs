using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResourceListItem : MonoBehaviour
{
    [SerializeField]
    Image icon;
    [SerializeField]
    TextMeshProUGUI label;

    public void UpdateView(Sprite sprite, string label)
    {
        icon.sprite = sprite;
        this.label.text = label;
    }
}
