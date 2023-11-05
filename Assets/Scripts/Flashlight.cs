using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Flashlight : MonoBehaviour
{
    public Light beam;
    private MeshRenderer flashlight;
    public TMP_Text tooltip; 

    private void Start()
    {
        beam.enabled = false;
        flashlight = GetComponent<MeshRenderer>();
        tooltip.enabled = false;
    }

    private void Update()
    {
        if(flashlight.enabled)
        {
            if(tooltip != null)
            {
                tooltip.enabled = true;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                beam.enabled = !beam.enabled;
                Destroy(tooltip);
            }
        }

    }
}
