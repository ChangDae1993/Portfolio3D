using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour 
{
	GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.forward * 5.0f);

		Destroy(this.gameObject, 5.0f);
	}
}
