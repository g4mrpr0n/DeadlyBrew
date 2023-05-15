using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private int DialogueType;

    [SerializeField] public Sprite firstSprite, secondSprite;
    [SerializeField] private GameObject PlayerObject;
    private SpriteRenderer spriteRenderer;

    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    private bool isDisplayingSentence = false; // Flag variable to track if a sentence is being displayed
    private bool hasWaited = false;
    
    private float timer = 0;
    private readonly float stateChangeTime = 6;


    private void Start()
    {
        if (DialogueType == 0)
        {
            NextSentence();
        }
        PlayerObject = GameObject.Find("PlayerObject");
        
        spriteRenderer = PlayerObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {

        timer += Time.deltaTime;
        if (timer >= stateChangeTime && DialogueType==1 && !hasWaited)
        {
            NextSentence();
            hasWaited = true;
            spriteRenderer.sprite = secondSprite;
        }
        if (DialogueType == 1 && Input.GetButtonDown("Submit") && hasWaited)
        {
            if (!isDisplayingSentence) // Check if a sentence is not being displayed
            {
                NextSentence();
            }
        }
    }

    void NextSentence()
    {
        if (Index < Sentences.Length && !isDisplayingSentence) // Check if a sentence is not being displayed
        {
            DialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
        else
        {
            // Load a different scene when dialogue ends
            SceneManager.LoadScene("BeginningScene");
        }
    }

    IEnumerator WriteSentence()
    {
        isDisplayingSentence = true; // Set the flag to true to indicate that a sentence is being displayed

        foreach (char Character in Sentences[Index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }

        Index++;
        isDisplayingSentence = false; // Reset the flag to false as the current sentence is finished
    }
}
