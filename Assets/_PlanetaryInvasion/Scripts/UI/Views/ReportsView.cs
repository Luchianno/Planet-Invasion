using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
using System.Linq;

public class ReportsView : MonoBehaviour
{
    public GameObject ItemPrefab;

    public RectTransform ContentParent;


    List<ReportsViewItem> items = new List<ReportsViewItem>();

    public void Init(IEnumerable<StoryLogEntry> results)
    {
        Clear();

        // Debug.Log(results.Count());

        foreach (var resultItem in results)
        {
            var gameObject = Instantiate(ItemPrefab, ContentParent);

            var temp = gameObject.GetComponent<ReportsViewItem>();
            temp.Init(resultItem);
            temp.OnClicked += ReportClicked;
            items.Add(temp);
        }
    }

    void ReportClicked(StoryLogEntry reportView)
    {
        // screenManager.ShowScreen()
    }

    void Clear()
    {
        foreach (RectTransform item in ContentParent)
        {
            if (item != this.transform)
            {
                Destroy(item.gameObject);
            }
        }

        foreach (var item in items)
        {
            item.OnClicked -= ReportClicked;
            Destroy(item.gameObject);
        }

        items.Clear();
    }
}
