using UnityEngine;
using System.Collections;

public class EndManager : MonoBehaviour {

	public GameObject score;
	public int scoreCount;
	// Use this for initialization
	void Start () {
		//scoreCount = PlayerPrefs.GetInt("Score");
		//score.guiText.text += scoreCount.ToString();
		
		scoreCount = PlayerPrefs.GetInt("Score");
		score.guiText.text += scoreCount.ToString();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnGUI()
	{

		if(GUI.Button(new Rect(300,285,250,75),"Quit"))
		{
			PlayerPrefs.SetInt("currentScore",0);
			Application.LoadLevel("Menu");
			return;
		}
	}
}
