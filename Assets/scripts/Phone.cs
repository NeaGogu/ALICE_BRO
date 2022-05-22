using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Phone :Collider {

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
		dialogueManager.DisplayNextSentence();
	}
}
