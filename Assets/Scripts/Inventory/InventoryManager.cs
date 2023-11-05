using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Item> items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;
    public TMP_Text tooltip;
    public GameObject inventoryButton;

    //public Canvas Inventory

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        tooltip.enabled = false;
        inventoryButton.SetActive(false);
    }

    private void Update()
    {
        //ListItems();
        if(items.Count > 0)
        {
            tooltip.enabled = true;
            inventoryButton.SetActive(true);
        }
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void ListItems()
    {
        //Stop multiplying items in inventory
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject go = Instantiate(inventoryItem, itemContent);
            TMP_Text itemName = go.transform.Find("ItemName").GetComponent<TMP_Text>();
            Image itemIcon = go.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.sprite;
        }
    }
}
