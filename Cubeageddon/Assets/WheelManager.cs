using UnityEngine;
using System.Collections;

public class WheelManager : MonoBehaviour {
	
	public float vel;
	// Use this for initialization
	void Start () {
		vel = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {	
		if(this.transform.position.x > 22)
		{
			vel *= -1;	
		}
		if(this.transform.position.x < -22)
		{
			vel *= -1;	
		}
		this.transform.Translate(new Vector3(vel,0,0));
	}
}
