using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public GameObject cube;
	public int highScore;
	public GameObject HighScoreCounter;
	public AudioClip menuMusic;
	
	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt("HighScore");
		HighScoreCounter.guiText.text += highScore.ToString();
		audio.PlayOneShot(menuMusic);
	}
	
	// Update is called once per frame
	void Update () {
		cube.transform.Rotate(new Vector3(0,1,0));
	}
	
	void OnGUI(){	
		//Fix all of the buttons in the correct positions.
		//Start Button
		if(GUI.Button(new Rect(165,285,250,75),"Start"))
		{
			Application.LoadLevel("Level1");
			return;
		}
		
		//Quit Button
		if(GUI.Button(new Rect(575,282,250,75),"Quit"))
		{
			Application.Quit();
			return;
		}
		
		if(GUI.Button(new Rect(650,195,100,50),"Reset Score"))
		{
			PlayerPrefs.DeleteAll();
			highScore = 0;
			HighScoreCounter.guiText.text = "High-Score: " + highScore.ToString();
		}
	}
}
