using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.forward * 5.0f);
	}
}
