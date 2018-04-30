using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

	public float score = 0;
	public float scoreSpeed;
	public float rotateSpeed;
	private float rotxGimic = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
		if (Input.GetKey (KeyCode.Space) == true) {
			if (rotxGimic >= 5.0f) {
				rotxGimic += -rotateSpeed;
				if (rotxGimic <= 5.0f) {
					score += (int)Time.deltaTime * scoreSpeed;
					this.GetComponent<Text> ().text = "罪" + score.ToString ("F2") + "point";
				}
			}
		} else if (Input.GetKey (KeyCode.Space) == false) {
			if (rotxGimic <= 35.0f) {
				rotxGimic += rotateSpeed;
			}
		}	

	}


}

