using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class KeypadInput : MonoBehaviour
{
    [Header("Animation")]
    public GameObject door;
    public Animator animator;
    public bool animate;
    public float doorHint = 2f;

    [Header("Text")]
    public TMP_Text displayText;
    private string code = "5638";
    private bool displayingResult = false;
    private float displayTime = 1f; 

    [Header("Colors")]
    [SerializeField] private Color screenNormalColor = new(0.0f, 1.0f, 0.6f, 1f); //cyan
    [SerializeField] private Color screenDeniedColor = new(1f, 0f, 0f, 1f); //red
    [SerializeField] private Color screenGrantedColor = new(0f, 0.62f, 0.07f); //green
    [SerializeField] private Renderer panelMesh;
    private float screenIntensity = 2.5f;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip button;
    public AudioClip granted;
    public AudioClip denied;

    private void Awake()
    {
        panelMesh.material.SetVector("_EmissionColor", screenNormalColor * screenIntensity);
    }

    public void Number(int number)
    {
        displayText.text += number.ToString();
        audioSource.PlayOneShot(button);
    }

    public void Execute()
    {
        bool correct = displayText.text == code;

        if(!displayingResult)
        {
            StartCoroutine(DisplayResult(correct));
        }
        else
        {
            Debug.LogWarning("Couldn't process");
        }
    }

    private IEnumerator DisplayResult(bool correct)
    {
        displayingResult = true;

        if (correct) AccessGranted();
        else AccessDenied();

        yield return new WaitForSeconds(displayTime);
        displayingResult = false;

        if (correct)
        {
            StartCoroutine(OpenDoor());
            yield break;
        }
        Clear();
        panelMesh.material.SetVector("_EmissionColor", screenNormalColor * screenIntensity);
    }

    private void AccessGranted()
    {
        displayText.text = "Granted";
        panelMesh.material.SetVector("_EmissionColor", screenGrantedColor * screenIntensity);
        audioSource.PlayOneShot(granted);
        animate = true;
    }
    private void AccessDenied()
    {
        displayText.text = "Denied";
        panelMesh.material.SetVector("_EmissionColor", screenDeniedColor * screenIntensity);
        audioSource.PlayOneShot(denied);
    }

    public void Clear()
    {
        displayText.text = "";
        audioSource.PlayOneShot(button);
    }

    private void Update()
    {
        if(animate)
        {
            animator.SetBool("animate", true);
            print("Its Open");

            //StartCoroutine(OpenDoor());
            animate = false;
        }
    }

    private IEnumerator OpenDoor()
    {
        Camera cam = Camera.main;
        cam.transform.LookAt(door.transform.position);
        yield return new WaitForSeconds(doorHint);
        cam.transform.LookAt(gameObject.transform.position);
    }
}
