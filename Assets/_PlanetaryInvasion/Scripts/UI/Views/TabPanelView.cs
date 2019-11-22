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
    protected List<TabPanelViewElement> Tabs;
    [SerializeField]
    protected ToggleGroup toggleGroup;

    [SerializeField]
    protected Image ContentImage;
    [SerializeField]
    protected TextMeshProUGUI ContentText;

    [SerializeField]
    protected RectTransform storiesParent;
    [SerializeField]
    protected RectTransform techParent;

    [SerializeField]
    protected GameObject tabTogglePrefab;

    Dictionary<TabToggleView, TabPanelViewElement> dict = new Dictionary<TabToggleView, TabPanelViewElement>();

    void Start()
    {
        // clean stuff from editor mode
        foreach (Transform child in storiesParent.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in techParent.transform)
        {
            Destroy(child.gameObject);
        }

        // Tabs.ForEach(x => AddElement(x)); // for testing
    }

    public void Init(IEnumerable<StoryEntry> stories, IEnumerable<Tech> research)
    {
        foreach (var item in stories)
        {
            var element = new TabPanelView.TabPanelViewElement()
            {
                Name = item.Name,
                Content = item.Description,
                Image = item.Image
            };

            AddElement(element, storiesParent);
        }

        foreach (var item in research)
        {
            var element = new TabPanelView.TabPanelViewElement()
            {
                Name = item.Name,
                Content = item.Description,
                // Image = item. // TODO add pics to Tech
            };

            AddElement(element, techParent);
        }

        // toggleView.Toggle.isOn = toggleGroup.ActiveToggles().Count() == 0;
        // toggleChanged();
    }

    public void SwitchTo(StoryEntry entry)
    {
        var key = dict.FirstOrDefault(x => x.Value.Name == entry.Name).Key;
        // key
    }

    public void AddElement(TabPanelViewElement element, RectTransform parent)
    {
        var temp = Instantiate(tabTogglePrefab, Vector3.zero, Quaternion.identity, parent);
        var toggleView = temp.GetComponent<TabToggleView>();

        toggleView.Init(element.Name, toggleGroup);
        toggleView.OnValueChanged += ToggleChanged;

        dict.Add(toggleView, element);
        temp.SetActive(true);
    }

    public void Clear()
    {
        ContentImage.sprite = null;
        ContentText.text = string.Empty;

        foreach (var item in dict)
        {
            Destroy(item.Key);
        }
        dict.Clear();
    }

    void ToggleChanged(TabToggleView sender, bool value)
    {
        if (!value)
            return;

        ContentImage.sprite = dict?[sender].Image;
        ContentText.text = dict?[sender].Content;
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
