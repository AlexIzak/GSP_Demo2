using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class KeypadInteraction : MonoBehaviour
{
    private Outline outline;
    public GameObject player;
    private Vector3 distance;
    private Camera cam;
    public Transform keypadView;
    public bool keypadActive = false;
    public KeypadInput keypad;
    public TMP_Text useTooltip;
    public TMP_Text quitTooltip;

    private void Start()
    {
        outline = gameObject.GetComponent<Outline>();
        outline.enabled = true;
        outline.OutlineWidth = 0;
        cam = Camera.main;
        useTooltip.enabled = false;
        quitTooltip.enabled = false;
    }

    private void Update()
    {
        distance = gameObject.transform.position - player.transform.position;

        if(keypadActive)
        {
            quitTooltip.enabled = true;
        }

        if(keypadActive && Input.GetKeyDown(KeyCode.Space))
        {
            outline.enabled = true;
            quitTooltip.enabled = false;

            player.GetComponent<PlayerController>().enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            gameObject.GetComponent<BoxCollider>().enabled = true;
            keypadActive = false;
            cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
            cam.transform.rotation = player.transform.rotation;
        }
    }

    private void OnMouseOver()
    {
        if (gameObject.CompareTag("Keypad") && distance.magnitude < 1)
        {
            outline.enabled = true;
            outline.OutlineColor = Color.cyan;
            outline.OutlineWidth = 3f;
            useTooltip.enabled = true;
        }
        else
        {
            outline.enabled = false;
            useTooltip.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Keypad") && distance.magnitude < 1)
        {
            keypad.displayText.text = "";

            outline.enabled = false;

            player.GetComponent<PlayerController>().enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            gameObject.GetComponent<BoxCollider>().enabled = false;
            keypadActive = true;
            cam.transform.position = keypadView.position;
            cam.transform.rotation = keypadView.rotation;
        }
    }


    private void OnMouseExit()
    {
        outline.enabled = false;
        useTooltip.enabled = false;
    }
}
