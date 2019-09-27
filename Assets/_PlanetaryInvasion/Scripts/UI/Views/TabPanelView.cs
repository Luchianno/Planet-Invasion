using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class TabPanelView : MonoBehaviour
{
    [SerializeField]
    List<TabPanelViewElement> Tabs;
    [SerializeField]
    ToggleGroup toggleGroup;

    [SerializeField]
    Image ContentImage;
    [SerializeField]
    TextMeshProUGUI ContentText;

    [SerializeField]
    RectTransform togglesParent;

    [SerializeField]
    GameObject tabTogglePrefab;

    Dictionary<Toggle, TabPanelViewElement> dict = new Dictionary<Toggle, TabPanelViewElement>();

    void Start()
    {
        // Tabs.ForEach(x => AddElement(x)); // for testing
    }

    public void AddElement(TabPanelViewElement element)
    {
        var temp = Instantiate(tabTogglePrefab, Vector3.zero, Quaternion.identity, togglesParent);
        var toggleView = temp.GetComponent<TabToggleView>();
        toggleView.SetLabel(element.Name);

        toggleView.OnValueChanged.AddListener(x => toggleChanged());
        this.toggleGroup.RegisterToggle(toggleView.Toggle);

        dict.Add(toggleView.Toggle, element);
        temp.SetActive(true);

        toggleView.Toggle.isOn = toggleGroup.ActiveToggles().Count() == 0;
        toggleChanged();
    }

    public void Clear()
    {
        ContentImage.sprite = null;
        ContentText.text = string.Empty;

        foreach (var item in dict)
        {
            this.toggleGroup.UnregisterToggle(item.Key);
            Destroy(item.Key);
        }
        dict.Clear();
    }

    void toggleChanged()
    {
        var active = this.toggleGroup.ActiveToggles().FirstOrDefault();
        ContentImage.sprite = dict?[active].Image;
        ContentText.text = dict?[active].Content;
    }

    [Serializable]
    public class TabPanelViewElement
    {
        public string Name;
        public Sprite Image;
        [TextArea]
        public string Content;
    }
}
