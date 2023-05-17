using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookSection : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject questSign;
    public GameObject leftArrow;
    public TextMeshProUGUI dialogText;
    public CameraFollow c;
    public string[] dialog;
    private int index;
    public bool dialogActive;
    public float wordSpeed;
    private bool isTyping = false; // Flag variable to track if a sentence is being typed

    private void Update()
    {
        if (Input.GetButtonDown("Submit") && dialogActive && !isTyping) // Check if not typing
        {

            questSign.SetActive(false);


            if (dialogBox.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialogBox.SetActive(true);
                StartCoroutine(Typing());
            }
        }
    }

    IEnumerator Typing()
    {
        isTyping = true; // Set the flag to true to indicate that a sentence is being typed

        foreach (char letter in dialog[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

        isTyping = false; // Reset the flag to false as the sentence typing is finished
    }

    public void NextLine()
    {
        if (!isTyping) // Check if not typing
        {
            if (index < dialog.Length - 1)
            {
                index++;
                dialogText.text = "";
                StartCoroutine(Typing());
            }
            else
            {
                zeroText();
            }
        }
    }

    private void zeroText()
    {
        dialogText.text = "";
        index = 0;
        dialogBox.SetActive(false);
        leftArrow.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogActive = false;
            zeroText();
        }
    }
}
