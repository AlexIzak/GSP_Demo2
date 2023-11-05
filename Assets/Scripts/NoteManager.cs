using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{
    public Canvas note;
    public TMP_Text text;
    public GameObject textPanel;
    public GameObject backgroundPanel;

    public TMP_Text tooltip;
    public PlayerController playerController;

    private void Start()
    {
        note.enabled = false;
        //text = GetComponent<TextMeshProUGUI>();
        text.enabled = false;
        textPanel.SetActive(false);
        tooltip.enabled = false;
        backgroundPanel.SetActive(false);
    }

    private void Update()
    {
        //var panel = text.transform.Find("Panel").GetComponent<Image>();
        //panel.enabled = false;

        if(note.enabled)
        {
            tooltip.enabled = true;
            backgroundPanel.SetActive(true);
            playerController.enabled = false;
        }

        if (note.enabled && Input.GetKeyDown(KeyCode.T))
        {
            text.enabled = !text.enabled;
            textPanel.SetActive(!textPanel.activeSelf);
        }

        if (note.enabled && Input.GetKeyDown(KeyCode.Q))
        {
            note.enabled = false;
            tooltip.enabled = false;
            backgroundPanel.SetActive(false);
            playerController.enabled = true;
        }
    }
}
