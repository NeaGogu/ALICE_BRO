using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public TextMeshProUGUI dialogueText;
    public Animator animator;
    
    private Queue<string> sentences;

    private string personName;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    

    public void StartDialogue(Dialogue dialogue) {
        
        animator.SetBool("isOpen", true);
        Debug.Log("Starting convo with" + dialogue.name);
        personName = "<< " + dialogue.name + " >> \n";
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        Debug.Log("Sentence: " + sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(personName + sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue() {
        animator.SetBool("isOpen", false);
    }
  
}
