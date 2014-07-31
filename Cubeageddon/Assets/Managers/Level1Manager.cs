using UnityEngine;
using System.Collections;

public class Level1Manager : MonoBehaviour {
	
	public GameObject scoreCounter;
	public int score;
	public int HighScore;
	public int halo;
	public GameObject ship;
	public GameObject end;
	public GameObject cubes;
	public Material pauseMenuScreenColor;
	public bool paused;
	public AudioClip level1Music;
	// Use this for initialization
	void Start () {
		HighScore = PlayerPrefs.GetInt("HighScore");
		score = 0;
		PlayerPrefs.SetInt("Score",score);
		scoreCounter.guiText.text += score.ToString();
		
		for(int i = 0; i < 100; i++)
		{
			Instantiate(cubes,new Vector3(Random.Range(-24,24),1,Random.Range(10,475)),Quaternion.identity);
		}
		
		pauseMenuScreenColor.SetColor("_Color",new Color(0,0,0,0));
		paused = false;
		audio.PlayOneShot(level1Music);
	}
	
	// Update is called once per frame
	void Update () {	
		if(paused == true)
		{
			pauseMenuScreenColor.SetColor("_Color",new Color(0,0,0,0.6f));
			ship.rigidbody.Sleep();
		}
		if(paused == false)
		{
			pauseMenuScreenColor.SetColor("_Color",new Color(0,0,0,0));
			ship.rigidbody.WakeUp();
			doThings();
		}
	}
	
	void scoreTick()
	{
		score++;
		scoreCounter.guiText.text = "Score: " + score.ToString();	
	}
	
	void doThings()
	{
		InvokeRepeating("scoreTick",0.5f,9999999999999999999);
		PlayerPrefs.SetInt("Score",score);
		if(score > HighScore)
			HighScore = score;
		PlayerPrefs.SetInt("HighScore",HighScore);
		PlayerPrefs.Save();
		if(ship.rigidbody.position.x > 23)
		{
			ship.rigidbody.AddForce(new Vector3(-200,0,0));
		}
		if(ship.rigidbody.position.x < -23)
		{
			ship.rigidbody.AddForce(new Vector3(200,0,0));
		}
		end.transform.Rotate(new Vector3(0,0,5));
		//change the force to Z for pushing the device out.
		ship.rigidbody.AddForce(new Vector3(Input.acceleration.x*100,0,5));
	}
	
	void OnGUI()
	{
		//fix pause button
		//if(GUI.Button(new Rect(900,375,75,40),"Pause"))
		//{
		//	if(paused == true)
		//	{
		//		paused = false;
		//		return;
		//	}
		//	if(paused == false)
		//	{
		//		paused = true;
		//		return;
		//	}
		//}
	}
}
