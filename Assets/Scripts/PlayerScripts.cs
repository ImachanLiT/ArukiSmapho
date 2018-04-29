using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour {

	public float slideSpeed;
	public GameObject smapho;
	public float rotateSpeed;
	public float ySpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float pos_x = transform.position.x;
		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (pos_x > -2.2f) {
				transform.position += Vector3.left * slideSpeed * Time.deltaTime;
			}
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			if (pos_x < 2.2f) {
				transform.position += Vector3.right * slideSpeed * Time.deltaTime;
			}
		}

		//smartphone
		if (Input.GetKey(KeyCode.Space) == true){
			if (smapho.transform.rotation.x < 0.0f) {
				smapho.transform.rotation = Quaternion.Euler ( smapho.transform.rotation.x + Time.deltaTime * rotateSpeed, smapho.transform.rotation.y, smapho.transform.rotation.z);
			}
			if(smapho.transform.position.y <0.4f){
					smapho.transform.position += new Vector3 (0.0f,ySpeed, 1.523236e-10f);
			}
		} else if(Input.GetKey(KeyCode.Space) == false){
			if (smapho.transform.rotation.x >= -90.0f) {
				smapho.transform.rotation = Quaternion.Euler ( smapho.transform.rotation.x - Time.deltaTime * rotateSpeed, smapho.transform.rotation.y, smapho.transform.rotation.z);
			}
			if(smapho.transform.position.y >0.0f){
					smapho.transform.position += new Vector3 (0.0f,-ySpeed, 0.0f);
			}		
		}
	}

}
