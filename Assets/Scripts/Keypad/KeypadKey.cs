using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadKey : MonoBehaviour
{
    public int value;

    public KeypadInput keypad;

    private void OnMouseDown()
    {
        if (gameObject.GetComponentInChildren<BoxCollider>().CompareTag("Number") && keypad.displayText.text.Length < 4)
        {
            keypad.Number(value);
        }
        else if(gameObject.GetComponentInChildren<BoxCollider>().CompareTag("Enter"))
        {
            keypad.Execute();
        }
        else if(gameObject.GetComponentInChildren<BoxCollider>().CompareTag("Clear"))
        {
            keypad.Clear();
        }
    }
}
