using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockBScript : MonoBehaviour {

	public float wallSpeed = -1.0f;
	public GameObject wall1;
	public GameObject start1;

	public float interval;
	float timer ;

	// Use this for initialization
	void Start () {

		timer = interval;

		start1.transform.position = wall1.transform.position + new Vector3 (0.0f, 0.0f, 50.0f);
		start1.transform.rotation = wall1.transform.rotation;
		//start2.transform.position = wall2.transform.position;

	}

	// Update is called once per frame
	void Update () {


		wall1.transform.position += Vector3.forward * wallSpeed * Time.deltaTime;
		//wall2.transform.position += Vector3.forward * wallSpeed * Time.deltaTime;

		timer -= Time.deltaTime;
		if (timer < 0) {
			Spawn ();
			timer = interval; 
		}
	}

	void Spawn(){
		Instantiate (wall1, start1.transform.position, start1.transform.rotation);
		//Instantiate (wall2, start2.transform.position, start2.transform.rotation);
	}
}

