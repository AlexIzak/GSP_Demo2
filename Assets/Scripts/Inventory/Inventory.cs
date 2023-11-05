using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    private PickUp pickUp;

    public Canvas inventoryScreen;

    // Start is called before the first frame update
    void Start()
    {
        items.Clear();
        inventoryScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryScreen.enabled = true;
        }

        foreach(GameObject item in items)
        {
            //Display on inventory screen

            //If 2 or more of the same item exist, create a variable and add to it - it will be displayed as text on the screen next to the original item
            //To do this, we need to parse the list and keep track of how much of each unique item we have
        }

        //Create function to handle taking an item out of the inventory - this will require the clicked item as a parameter which will be enabled back into the world,
        //at the position of the player - RemoveItem(gameobject itemToDrop, vector3 dropLocation) - dropped items should be able to be picked up

        //Create a function to use items - this will require a check to see if the item is usable, followed by something to symbolise the item has been used
    }
}
