using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	private Queue<string> sentencesL;
	private Queue<string> sentencesR;
	public Text lText;
	public Text rText;
		
	// Use this for initialization
	void Start () {
		sentencesL = new Queue<string>();
		sentencesR = new Queue<string>();
	}
	
	public void StartDialouge(Dialogue dialogue){

		//Debug.Log("starting conversationg with " + dialogue.surveyName);

		//sentencesL.Clear();
		//sentencesR.Clear();
		
		foreach(string sentence in dialogue.sentences){
			
			if(dialogue.surveyName == "Left"){
				sentencesL.Enqueue(sentence);				
			}else if(dialogue.surveyName == "Right"){
				sentencesR.Enqueue(sentence);				
			}else{
				Debug.Log("failed to enqueue: " + sentence + " for " + dialogue.surveyName);
			}												
		}

		DisplayNextSentence(dialogue.surveyName);
	}

	public void DisplayNextSentence(string name){
				
		if(sentencesL.Count == 0 && sentencesR.Count == 0){
			EndDialogue();
			return;
		}else{
			if(name == "Left"){
				string Rsentence = sentencesL.Dequeue();
				lText.text = Rsentence;
			}else if(name == "Right"){
				string Lsentence = sentencesR.Dequeue();
				rText.text = Lsentence;
			}		
								
		}
	}

	public void EndDialogue(){
		Debug.Log("The survey has ended.");
	}
}
