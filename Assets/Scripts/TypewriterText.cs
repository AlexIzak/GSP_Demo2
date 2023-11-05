using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterText : MonoBehaviour
{
    private TMP_Text subtitleText;
    private string sentence;

    private float textDelay = 0.07f;
    private float removeDelay = 1.7f;

    private AudioSource dialogue;

    public void Dialogue()
    {
        dialogue = GetComponent<AudioSource>();
        subtitleText = GetComponent<TMP_Text>();

        sentence = subtitleText.text;
        subtitleText.text = "";

        dialogue.Play();
        StartCoroutine(WriteText());
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Player"))
    //    {
    //        dialogue.enabled = true;
    //        subtitleText.enabled = true;

    //        sentence = subtitleText.text;
    //        subtitleText.text = "";

    //        dialogue.Play();
    //        StartCoroutine(WriteText());
    //    }
    //}

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(removeDelay);
        subtitleText.enabled = false;
        //Destroy(gameObject);
    }

    private IEnumerator WriteText()
    {
        foreach (char c in sentence)
        {
            subtitleText.text += c;
            yield return new WaitForSeconds(textDelay);
        }

        StartCoroutine(Delay());
    }
}
