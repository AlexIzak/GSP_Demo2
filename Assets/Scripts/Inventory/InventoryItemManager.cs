using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryItemManager : MonoBehaviour
{
    public Item item;

    public void UseItem()
    {
        TMP_Text name = gameObject.transform.Find("ItemName").GetComponent<TMP_Text>();

        switch(name.text)
        {
            case "Flashlight":
                GameObject.Find(name.text).GetComponent<MeshRenderer>().enabled = true;
                //print("Click!");
                break;

            case "Note 1":
                GameObject.Find("Canvas - " + name.text).GetComponent<Canvas>().enabled = true;
                //print("Click!");
                break;

            case "Note 2":
                GameObject.Find("Canvas - " + name.text).GetComponent<Canvas>().enabled = true;
                //print("Click!");
                break;
        }

        GameObject.Find("Canvas - Inventory").SetActive(false);

        print(name.text);
        //print("Click!");
    }
}
