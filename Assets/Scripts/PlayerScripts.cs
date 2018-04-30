using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScripts : MonoBehaviour {

	public float slideSpeed;
	public GameObject smapho;
	public float rotateSpeed;
	public float ySpeed;

	public Text ScoreText;
	public float scoreSpeed = 1.0f;
	public float score = 0.0f;

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

		//float Xaxis = smapho.transform.rotation.eulerAngles.x;

		//smartphone-----------
		if (Input.GetKey (KeyCode.Space) == true) {
			if (smapho.transform.rotation.eulerAngles.x >= 5.0f) {
				smapho.transform.Rotate (-rotateSpeed, 0.0f, 0.0f);
				//score UI
				score += Time.deltaTime * scoreSpeed;
			}
		} else if (Input.GetKey (KeyCode.Space) == false) {
			if (smapho.transform.rotation.eulerAngles.x <= 35.0f) {
				smapho.transform.Rotate (rotateSpeed, 0.0f, 0.0f);
			}
		}
			
		//score UI
		ScoreText.text = "罪"+ score.ToString ("F2") + "point";

	}

	void OnTriggerEnter(Collider collider){
		// GameOverText = true;
	}

}
