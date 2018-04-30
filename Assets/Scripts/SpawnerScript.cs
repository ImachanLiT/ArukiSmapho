using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

	public GameObject spawnedObject;
	public float interval = 3;
	float timer = 0;

	void Update () {
		timer -= Time.deltaTime; 
		if (timer < 0) { 
			//spawner-x-position changes to the random
			this.transform.position = new Vector3 (Random.Range(-2.2f,2.2f), this.transform.position.y, this.transform.position.z);
			Spawn (); 
			timer = interval + Random.Range(0.0f, 2.0f); 

		}
	}

	void Spawn(){
		Instantiate (spawnedObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
	}


}
