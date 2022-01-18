using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public GameObject dialogueWindow;
    public GameObject continueButton;    
    public TMPro.TMP_Text nameText;
    public TMPro.TMP_Text dialogueText;
    private static bool GameIsPaused;
    public Animator animator;
    private float timeDelay = 0.075f;

    void Start()
    {
        GameEvents.current.onGamePause += PauseGame;
        GameEvents.current.onGameUnpause += UnpauseGame;
        GameEvents.current.onTriggerDialogue += StartDialogue;        
        sentences = new Queue<string>();
    }
    void PauseGame()
    {
        GameIsPaused = true;
    }
    void UnpauseGame()
    {
        GameIsPaused = false;
    }
    private void Update()
    {
        if (GameIsPaused) 
        {           
            sentences.Clear();
            dialogueWindow.SetActive(false);
        }        
    }
    public void StartDialogue(Dialogue dialogue)
    {
        if (!GameIsPaused)
        {
            GameEvents.current.UIOpen();
            dialogueWindow.SetActive(true);
            continueButton.SetActive(true);            
            animator.SetBool("IsOpen", true);            
            nameText.text = dialogue.name;
            Debug.Log("Starting Coversation with" + dialogue.name);

            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();            
             Debug.Log("End of Conversation");
             return;
        }
        string sentance = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentance));
        
    }
    IEnumerator TypeSentence(string sentence) 
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(timeDelay);
        }
    }
    public void EndDialogue()
    {
        GameEvents.current.UIClosed();
        sentences.Clear();
        animator.SetBool("IsOpen", false);        
    }    
    
}
