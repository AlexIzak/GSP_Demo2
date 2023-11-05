using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypewriterTrigger : MonoBehaviour
{
    public TMP_Text text;
    public TypewriterText dialogue;

    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        text.enabled = true;
        dialogue.Dialogue();
        Destroy(gameObject);
    }
}
