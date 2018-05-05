using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;

public class PlayerScripts : MonoBehaviour {

	public float slideSpeed;
	public GameObject smapho;
	public float rotateSpeed;
	public float ySpeed;

	public Text ScoreText;
	public float scoreSpeed = 1.0f;
	private float scoreTimer = 0.0f;
	public float score;
	public GameObject level2Object;

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetFloat ("point");
		if (PlayerPrefs.GetInt ("level") == 1) {
			level2Object.gameObject.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("level") == 2) {
			scoreSpeed = 0.1f;
		} else if (PlayerPrefs.GetInt ("level") >= 3) {
			scoreSpeed = 0.5f;
		}
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

			}
		} else if (Input.GetKey (KeyCode.Space) == false) {
			
			scoreTimer = 0.0f;
			if (smapho.transform.rotation.eulerAngles.x <= 35.0f) {
				smapho.transform.Rotate (rotateSpeed, 0.0f, 0.0f);
			}
		}
			
		//score UI
		if (smapho.transform.rotation.eulerAngles.x <= 5.0f) {
			scoreTimer += Time.deltaTime;
			score += scoreTimer*scoreTimer * scoreSpeed;
			ScoreText.text = "罪" + score.ToString ("F2") + "point";
			PlayerPrefs.SetFloat ("point",score);
		}
	}

	void OnTriggerEnter(Collider other){

		PlayerPrefs.SetFloat ("point",score);
		SceneManager.LoadScene ("GameOver");


	}



}


