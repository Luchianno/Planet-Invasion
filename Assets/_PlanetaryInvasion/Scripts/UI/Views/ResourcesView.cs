using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ResourcesView : MonoBehaviour, IUpdateableView
{
    [Inject]
    PlanetState gameState;

    [SerializeField]
    RectTransform parent;
    [SerializeField]
    GameObject itemPrefab;

    void Start()
    {
        UpdateView();
    }

    public void UpdateView()
    {
        foreach (Transform item in parent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in gameState.Player.Resources)
        {
            var temp = Instantiate(itemPrefab, parent);
            temp.GetComponent<ResourceListItem>().UpdateView(item.Key.Icon, $"{item.Key.Name} {item.Value}");
        }
    }
}
