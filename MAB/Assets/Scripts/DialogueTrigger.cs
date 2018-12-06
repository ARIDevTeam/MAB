using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	void Start(){
		TextAsset surveyQs = Resources.Load<TextAsset>("discSurvey");
		string[] data = surveyQs.text.Split(new char[]{'\n'});
		//Debug.Log(data.Length);
		Array.Resize(ref dialogue.sentences, data.Length-1);
		Array.Resize(ref dialogue.reverse, data.Length-1);

		for(int i = 1; i<data.Length; i++){
			string[] row = data[i].Split(new char[]{','});
			if(gameObject.tag == "Left"){
				dialogue.sentences[i-1] = row[0];
				int.TryParse(row[2], out dialogue.reverse[i-1]);
			}else if(gameObject.tag == "Right"){
				dialogue.sentences[i-1] = row[1];
				int.TryParse(row[2], out dialogue.reverse[i-1]);
			}
			
		}
	}

	public void TriggerDialogue(){
		FindObjectOfType<DialogueManager>().StartDialouge(dialogue);
	}

	public void TriggerNextDialogue(){
		//Debug.Log("my tag name is: " + gameObject.tag);
		FindObjectOfType<DialogueManager>().DisplayNextSentence(gameObject.tag);
	}
}
