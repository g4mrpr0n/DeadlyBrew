using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialogueBoxNPC, dialogueBoxPlayer, hair, claw;
    public TextMeshProUGUI dialogueTextNPC, dialogueTextPlayer;
    public string[] dialoguePlayer, dialogueNPC, convoEnd, dialogue1Pl, dialogue1NPC;
    private string str = "HairUI", str1 = "ClawUI";
    
    private int index=0;
    private bool isNPCSpeaking = true; // Flag variable to track if it's currently the NPC's turn to speak
    public bool dialogActive;
    public float wordSpeed;
    private bool isTyping = false; // Flag variable to track if a sentence is being typed
    public bool conversationEnded = false;
    private bool didntDo = false;
    private bool finishingConvo = false;
    private GameObject Inventory;
    private GameObject InventoryCanvas;


    private void Start()
    {
        hair = GameObject.Find("Inventory").transform.Find("InventoryUI").Find(str).gameObject;
        claw = GameObject.Find("Inventory").transform.Find("InventoryUI").Find(str1).gameObject;
    }

    private void Awake()
    {
        dialogueBoxNPC.SetActive(false);
        dialogueBoxPlayer.SetActive(false);


    }

    private void Update()
    { 
        if (hair.activeInHierarchy)
        {
            finishingConvo = true;
        }
        if (Input.GetButtonDown("Submit") && dialogActive && !isTyping) // Check if not typing
        {
            
            
            if ((dialogueBoxNPC.activeInHierarchy || dialogueBoxPlayer.activeInHierarchy) && !conversationEnded)
            {
                NextLine();
            }
            else if (isNPCSpeaking && index < dialogueNPC.Length && !conversationEnded &&!finishingConvo)
            {
                dialogueBoxNPC.SetActive(true);
                StartCoroutine(Typing(dialogueNPC, dialogueTextNPC));
            }
            else if (isNPCSpeaking && index < dialogue1NPC.Length && !conversationEnded && finishingConvo)
            {
                dialogueBoxNPC.SetActive(true);
                StartCoroutine(Typing(dialogue1NPC, dialogueTextNPC));

            }
            else if (!isNPCSpeaking && index < dialoguePlayer.Length && !conversationEnded && !finishingConvo)
            {
                dialogueBoxPlayer.SetActive(true);
                StartCoroutine(Typing(dialoguePlayer, dialogueTextPlayer));
            }
            else if (!isNPCSpeaking && index < dialogue1Pl.Length && !conversationEnded && finishingConvo)
            {
                dialogueBoxPlayer.SetActive(true);
                StartCoroutine(Typing(dialogue1Pl, dialogueTextPlayer));
            }
            else if (conversationEnded && !dialogueBoxNPC.activeInHierarchy)
            {
                dialogueBoxNPC.SetActive(true); // Show NPC dialogue box
                StartCoroutine(Typing(convoEnd, dialogueTextNPC));
            }
            else
            {
                if (finishingConvo)
                {
                    claw.SetActive(true);
                }
                EndDialogue();
            }
            
        }
    }

    IEnumerator Typing(string[] dialogue, TextMeshProUGUI textBox)
    {
        isTyping = true; // Set the flag to true to indicate that a sentence is being typed
        foreach (char letter in dialogue[index].ToCharArray())
        {
            if (!dialogActive)
            {
                didntDo = true;
                yield return null;
                EndDialogue();
                break;
            }
            textBox.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        isNPCSpeaking = !isNPCSpeaking;
        if (didntDo)
        {
            isNPCSpeaking = true;
            didntDo = false;
        }
        isTyping = false; // Reset the flag to false as the sentence typing is finished
    }

    public void NextLine()
    {
        if (!isTyping) // Check if not typing
        {
            if (isNPCSpeaking && index < dialogueNPC.Length && !finishingConvo)
            {
                dialogueBoxPlayer.SetActive(false); // Hide player dialogue box
                dialogueBoxNPC.SetActive(true); // Show NPC dialogue box
                dialogueTextNPC.text = ""; // Clear NPC dialogue text
                StartCoroutine(Typing(dialogueNPC, dialogueTextNPC));

            }
            else if (isNPCSpeaking && index < dialogue1NPC.Length && finishingConvo)
            {
                dialogueBoxPlayer.SetActive(false); // Hide player dialogue box
                dialogueBoxNPC.SetActive(true); // Show NPC dialogue box
                dialogueTextNPC.text = ""; // Clear NPC dialogue text
                StartCoroutine(Typing(dialogue1NPC, dialogueTextNPC));
            }
            else if (!isNPCSpeaking && index < dialoguePlayer.Length && !finishingConvo)
            {
                dialogueBoxPlayer.SetActive(true); // Show player dialogue box
                dialogueBoxNPC.SetActive(false); // Hide NPC dialogue box
                dialogueTextPlayer.text = ""; // Clear player dialogue text
                StartCoroutine(Typing(dialoguePlayer, dialogueTextPlayer));


                index++;
            }
            else if (!isNPCSpeaking && index < dialogue1Pl.Length && finishingConvo)
            {
                dialogueBoxPlayer.SetActive(true); // Show player dialogue box
                dialogueBoxNPC.SetActive(false); // Hide NPC dialogue box
                dialogueTextPlayer.text = ""; // Clear player dialogue text
                StartCoroutine(Typing(dialogue1Pl, dialogueTextPlayer));
                index++;
            }
            
            else
            {
                if (finishingConvo)
                {
                    claw.SetActive(true);
                }
                conversationEnded = true;
                EndDialogue();
            }
        }
    }

    private void EndDialogue()
    {
        dialogueBoxNPC.SetActive(false);
        dialogueBoxPlayer.SetActive(false);
        dialogueTextNPC.text = "";
        dialogueTextPlayer.text = "";
        isNPCSpeaking = true;
        index = 0;
        
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
            EndDialogue();
        }
    }
}
