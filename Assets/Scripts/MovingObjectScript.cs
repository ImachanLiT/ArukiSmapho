using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectScript : MonoBehaviour {

	public float speed;
	public GameObject player;
	public GameObject movings;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		movings.transform.position += this.transform.forward * speed;

		if (player.transform.position.z > this.transform.position.z) {
			Destroy (movings.gameObject);
		}
			
	}
}
