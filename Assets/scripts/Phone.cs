using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Phone :Collider {

	public string[] sceneNames;
	private string scene;
	
	public DialogueTrigger triggerRabbit;
	public Animator animator;
	public DialogueManager dialogueManager;
	
	public AudioSource audioSource;

	private bool startedConversation = false;
	private float timeUntilRings;

	private void Awake() {
		animator.SetBool("isRinging", false);
		timeUntilRings = Random.Range(5, 10);
		audioSource.mute = true;

	}

	protected override void Update() {
		base.Update();
		timeUntilRings -= Time.deltaTime;

		if (timeUntilRings < 0 && !startedConversation) {
			animator.SetBool("isRinging", true);
			
			audioSource.mute = false;
		}
	}

	protected override void OnCollide(Collider2D coll) {
		// used to avoid recalling while colliding
		if (!startedConversation && animator.GetBool("isRinging"))	{
			startedConversation = true;
			animator.SetBool("isRinging", false);
			audioSource.Stop();
			triggerRabbit.TriggerDialogue();
		}
	}
	
	void OnInteract(InputValue value)
	{
		Debug.Log(value);

		if (!startedConversation) {
			return;
		}
		
		if (dialogueManager.sentencesRemaining() > 1) {
			dialogueManager.DisplayNextSentence();
			return;
		}

		if (dialogueManager.sentencesRemaining() == 0) {
			dialogueManager.DisplayNextSentence();
			animator.SetBool("isRinging", false);
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
