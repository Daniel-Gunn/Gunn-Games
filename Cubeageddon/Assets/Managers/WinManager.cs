using UnityEngine;
using System.Collections;

public class WinManager : MonoBehaviour {

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
		if(GUI.Button(new Rect(165,285,250,75),"Next Level"))
		{
			PlayerPrefs.SetInt("currentScore", scoreCount);
			Application.LoadLevel("Level2");
			return;
		}
		if(GUI.Button(new Rect(575,285,250,75),"Quit"))
		{
			PlayerPrefs.SetInt("currentScore",0);
			Application.LoadLevel("Menu");
			return;
		}
	}
}
