using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {
	
	public string surveyName;
	[TextArea(1,40)]
	public string[] sentences;
	public int[] reverse;
}
