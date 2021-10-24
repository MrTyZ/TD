using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateAround : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public float scroll = 0;
	public float sensitivity = 3;// чувствительность мышки
	private float X;

	void Start () 
	{
		
		offset = new Vector3(0, -2.5f, -32);		
		transform.position = target.position + offset;
		
	}

	void Update ()
	{
		
		if (Input.GetKey(KeyCode.A)) { scroll += 1; }
		if (Input.GetKey(KeyCode.D)) { scroll -= 1; }
		X = transform.localEulerAngles.y + scroll * sensitivity;
		scroll = 0;

		transform.localEulerAngles = new Vector3(70, X, 0);
		transform.position = transform.localRotation * offset + target.position;
	}
	
}