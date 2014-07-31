using UnityEngine;
using System.Collections;

public class LoseManager : MonoBehaviour {
	
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
		if(GUI.Button(new Rect(165,285,250,75),"Retry"))
		{
			if(Application.loadedLevelName == "LoseScreen")
			{
				Application.LoadLevel("Level1");
				return;
			}
			else
			{
				Application.LoadLevel("Level2");	
			}
		}
		if(GUI.Button(new Rect(575,285,250,75),"Quit"))
		{
			Application.LoadLevel("Menu");
			return;
		}
	}
}
