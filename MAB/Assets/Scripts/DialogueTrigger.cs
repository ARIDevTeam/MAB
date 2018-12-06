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
/****************Example Code ************************************

 private List<string[]> rowData = new List<string[]>();
    

    // Use this for initialization
    void Start () {
        Save();
    }
    
    void Save(){

        // Creating First row of titles manually..
        string[] rowDataTemp = new string[3];
        rowDataTemp[0] = "Name";
        rowDataTemp[1] = "ID";
        rowDataTemp[2] = "Income";
        rowData.Add(rowDataTemp);

        // You can add up the values in as many cells as you want.
        for(int i = 0; i < 10; i++){
            rowDataTemp = new string[3];
            rowDataTemp[0] = "Sushanta"+i; // name
            rowDataTemp[1] = ""+i; // ID
            rowDataTemp[2] = "$"+UnityEngine.Random.Range(5000,10000); // Income
            rowData.Add(rowDataTemp);
        }

        string[][] output = new string[rowData.Count][];

        for(int i = 0; i < output.Length; i++){
            output[i] = rowData[i];
        }

        int     length         = output.GetLength(0);
        string     delimiter     = ",";

        StringBuilder sb = new StringBuilder();
        
        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));
        
        
        string filePath = getPath();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }

    // Following method is used to retrive the relative path as device platform
    private string getPath(){
        #if UNITY_EDITOR
        return Application.dataPath +"/CSV/"+"Saved_data.csv";
        #elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_data.csv";
        #elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
        #else
        return Application.dataPath +"/"+"Saved_data.csv";
        #endif
    }
 *//