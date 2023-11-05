using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //public GameObject item;
    private Outline outline;

    public Canvas tooltipCanvas;

    public Item item;

    private Vector3 distance;
    public GameObject player;

    private void ItemPickUp()
    { 
        InventoryManager.instance.Add(item);
        gameObject.SetActive(false);
        //Destroy(gameObject);
        //item.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        //item.SetActive(false);

        outline = gameObject.GetComponent<Outline>();
        outline.enabled = true;
        outline.OutlineWidth = 0;

        tooltipCanvas.enabled = false;
    }

    private void Update()
    {
        distance = gameObject.transform.position - player.transform.position;
    }

    private void OnMouseOver()
    {
        if(gameObject.CompareTag("Selectable") && distance.magnitude < 2)
        {
            outline.enabled = true;
            outline.OutlineColor = Color.cyan;
            outline.OutlineWidth = 3f;
            tooltipCanvas.enabled = true;
        }
        else
        {
            outline.enabled = false;
            tooltipCanvas.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Selectable") && distance.magnitude < 2)
        {
            ItemPickUp();


            //item.SetActive(true);

            //Remove player movement and instead add rotations on the document
        }
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
        tooltipCanvas.enabled = false;
    }
}
