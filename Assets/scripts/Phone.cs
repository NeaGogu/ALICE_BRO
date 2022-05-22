using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Phone :Collider {

	public string[] sceneNames;
	private string scene;
	
	public DialogueTrigger trigger;
	public DialogueManager dialogueManager;
	private bool startedConversation = false;
	protected override void OnCollide(Collider2D coll) {
		if (!startedConversation )	{
			startedConversation = true;
			trigger.TriggerDialogue();
		}
		
	}
	
	void OnInteract(InputValue value)
	{
		Debug.Log(value);
		if (dialogueManager.sentencesRemaining() > 1) {
			dialogueManager.DisplayNextSentence();
			return;
		}

		if (dialogueManager.sentencesRemaining() == 0) {
			dialogueManager.DisplayNextSentence();
			Invoke("startNewGame", 5);
		}
	}

	void OnChooseOption1(InputValue value) {
		Debug.Log("Pressed 1");
		if (dialogueManager.sentencesRemaining() == 1) {
			scene = sceneNames[0];
			dialogueManager.DisplayNextSentence();
		}	
	}
	
	void OnChooseOption2(InputValue value) {
		Debug.Log("Pressed 2");
		if (dialogueManager.sentencesRemaining() == 1) {
			scene = sceneNames[1];
			dialogueManager.DisplayNextSentence();
		}
	}

	void startNewGame() {
		SceneManager.LoadScene(scene);
	}

}
