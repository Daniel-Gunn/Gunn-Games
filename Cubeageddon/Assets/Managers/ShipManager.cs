using UnityEngine;
using System.Collections;

public class ShipManager : MonoBehaviour {
	
	public GameObject ship;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Collision Detected");
		if(collision.gameObject.GetComponent<WinningManager>() != null)
		{
			Debug.Log("WON?");
			if(Application.loadedLevelName == "Level1")
			{
				Application.LoadLevel("WinScreen");
			}
			else
			{
				Debug.Log("End Game");
				Application.LoadLevel("EndScreen");	
			}
			
		}
		if(collision.gameObject.GetComponent<ObstacleManager>() != null)
		{
			Debug.Log("BAM");
			if(Application.loadedLevelName == "Level1")
			{
				Application.LoadLevel("LoseScreen");
			}
			else
			{
				Application.LoadLevel("LoseScreen2");
			}
		}
	}
}
