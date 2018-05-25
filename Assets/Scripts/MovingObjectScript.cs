using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectScript : MonoBehaviour {

	public float speed;
	public GameObject player;
	public GameObject movings;
	public float angulV;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{	

		movings.transform.position += this.transform.forward * speed;
		if (movings.transform.position.x <= -2.0f && angulV != 0.0f) {
			movings.transform.rotation = Quaternion.Euler (0.0f,-angulV, 0.0f);
		} else if(movings.transform.position.x >= 2.0f && angulV != 0.0f){
			movings.transform.rotation = Quaternion.Euler (0.0f, angulV, 0.0f);
		}

		if (player.transform.position.z > this.transform.position.z) {
			Destroy (movings.gameObject);
		}

		if (PlayerPrefs.GetInt ("level") == 3  ) {
			movings.SetActive (true);
			if (movings.transform.position.y >= 0.8f) {
				movings.transform.rotation = Quaternion.Euler (angulV, this.transform.rotation.eulerAngles.y, 0.0f);
			} else{
				movings.transform.rotation = Quaternion.Euler (0.0f, this.transform.rotation.eulerAngles.y, 0.0f);
			}
		}


	}
}
