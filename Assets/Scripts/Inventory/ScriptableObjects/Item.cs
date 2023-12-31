using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public Sprite sprite;
    private Outline outline;
    public itemTypes itemType;

    public GameObject itemObject;

    public enum itemTypes
    {
        Flashlight,
        Note
    }
}
