using UnityEngine;
using System.Collections;

public class Level2Manager : MonoBehaviour {
	
	public GameObject scoreCounter;
	public int score;
	public int HighScore;
	public int halo;
	public GameObject ship;
	public GameObject end;
	public Material pauseMenuScreenColor;
	public bool paused;
	public Quaternion rotation;	
	public AudioClip level2Music;
	public GameObject wheel;
	
	// Use this for initialization
	void Start () {
		HighScore = PlayerPrefs.GetInt("HighScore");
		score = PlayerPrefs.GetInt("currentScore");;
		scoreCounter.guiText.text += score.ToString();
		pauseMenuScreenColor.SetColor("_Color",new Color(0,0,0,0));
		paused = false;
		rotation = Quaternion.identity;
		rotation.eulerAngles = new Vector3(90,0,0);
		
		for(int i = 0; i < 25; i++)
		{
			Instantiate(wheel,new Vector3(Random.Range(-22,22),1,Random.Range(10,475)),rotation);
		} 
		audio.PlayOneShot(level2Music);
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
//		if(GUI.Button(new Rect(900,375,75,40),"Pause"))
//		{
//			if(paused == true)
//			{
//				paused = false;
//				return;
//			}
//			if(paused == false)
//			{
//				paused = true;
//				return;
//			}
//		}
	}
}
