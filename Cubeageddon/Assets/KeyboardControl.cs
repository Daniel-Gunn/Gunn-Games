//COPYRIGHT 2014 React! Games
using UnityEngine;
using System.Collections;

public class KeyboardControl : MonoBehaviour 
{
	public Vector3 movement = new Vector3(50,0,0);
	public float rotationDegree = 10;
	bool click = false;

	void Update()
	{
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position -= movement * Time.deltaTime;
			if(!click)
			{
				transform.RotateAround(new Vector3(0,0,1),rotationDegree * Time.deltaTime);
				click = true;
			}
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += movement * Time.deltaTime;
			if(!click)
			{
				transform.RotateAround(new Vector3(0,0,1),-rotationDegree * Time.deltaTime);
				click = true;
			}
		}
		else
		{
			if(click)
				click = false;
			if(transform.eulerAngles.z != 0)
			{
				transform.eulerAngles = new Vector3(0,180,0);
			}
		}
	}
}
