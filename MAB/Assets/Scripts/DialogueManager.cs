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
				//Debug.Log(dialogue.surveyName + "has added " + sentencesL.Count);
			}else if(dialogue.surveyName == "Right"){
				sentencesR.Enqueue(sentence);
				//Debug.Log(dialogue.surveyName + " has added " + sentencesR.Count);
			}else{
				Debug.Log("failed to enqueue: " + sentence + " for " + dialogue.surveyName);
			}												
		}

		DisplayNextSentence(dialogue.surveyName);
	}

	public void DisplayNextSentence(string name){
				
		//Debug.Log("The name passed to DisplayNextSentence was: " + name);
		if(sentencesL.Count == 0 && sentencesR.Count == 0){
			EndDialogue();
			return;
		}else{
			if(name == "Left"){
				string Rsentence = sentencesL.Dequeue();
				lText.text = Rsentence;
				//Debug.Log(Rsentence);
			}else if(name == "Right"){
				string Lsentence = sentencesR.Dequeue();
				rText.text = Lsentence;
				//Debug.Log(Lsentence);
			}		
								
		}
	}

	public void EndDialogue(){
		Debug.Log("The survey has ended.");
	}
}
