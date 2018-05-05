using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;

public class ScoreData : MonoBehaviour {

	public float timer = 0.0f;
	private bool next = false;
	
	public Text Text1, Text2score, Text3score, Text4;

	// Use this for initialization
	void Start () {
		

		float point = PlayerPrefs.GetFloat ("point");
		float highScore = PlayerPrefs.GetFloat ("highScore");
		float highScore2 = PlayerPrefs.GetFloat ("highScore2");
		float highScore3 = PlayerPrefs.GetFloat ("highScore3");

		if (point >= highScore) {
			PlayerPrefs.SetFloat ("highScore", point);
			PlayerPrefs.SetFloat ("highScore2", highScore);
			PlayerPrefs.SetFloat ("highScore3", highScore2);
		} else if (point < highScore && point >= highScore2) {
			PlayerPrefs.SetFloat ("highScore2", point);
			PlayerPrefs.SetFloat ("highScore3", highScore2);
		} else if (point < highScore2 && point >= highScore3) {
			PlayerPrefs.SetFloat ("highScore3", point);
		}

		Text1.gameObject.SetActive (false);
		Text2score.gameObject.SetActive (false);
		Text3score.gameObject.SetActive (false);
		Text4.gameObject.SetActive (false);

		PlayerPrefs.SetInt ("level",1);
			
	}




	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= 1.0f) {
			Text1.gameObject.SetActive(true);
		}
		if (timer >= 2.0f) {
			Text2score.text ="今回のあなたは\n\n罪" + PlayerPrefs.GetFloat ("point",0.0f) + " \n\nです";
			Text2score.gameObject.SetActive (true);
		}
		if (timer >= 3.0f) {
			Text3score.text = "１番悪人 : " + PlayerPrefs.GetFloat("highScore",10000f) 
				+ " \n２番悪人 : " + PlayerPrefs.GetFloat("highScore2",0.0f) + " \n３番悪人 : " + PlayerPrefs.GetFloat("highScore3",0.0f);
			Text3score.gameObject.SetActive (true);
		}
		if (timer >= 4.0f) {
			Text4.gameObject.SetActive (true);
			next = true;
		}
		if (next == true && Input.GetKey( KeyCode.Space)) {
			PlayerPrefs.SetFloat ("point",0.0f);
			SceneManager.LoadScene ("MainGame");

		}

			
	}
}
