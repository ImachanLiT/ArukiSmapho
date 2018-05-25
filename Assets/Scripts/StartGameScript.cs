using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour {

	private float timer1 = 0.0f;
	private float timer2 = 0.0f;
	private bool nextGame = false;
	public GameObject text1,text2 ,Title, TitleBoard, RuleText;
	public new AudioSource koukaon;

	void Start () {
		text1.gameObject.SetActive (false);
		PlayerPrefs.SetInt ("level",1);
		PlayerPrefs.SetFloat ("point",0.0f);
		
	}

	void Update () {
		
		if (nextGame == false) {
			timer1 += Time.deltaTime;
			if ((int)timer1 % 2 == 1) {
				text2.gameObject.SetActive (false);
			} else {
				text2.gameObject.SetActive (true);
			}
		}

		if (Input.GetKey (KeyCode.Space)) {
			koukaon.Play ();
			text2.gameObject.SetActive (false);
			Title.gameObject.SetActive (false);
			TitleBoard.gameObject.SetActive (false);
			RuleText.gameObject.SetActive (false);
			nextGame = true;
		}

		if (nextGame == true) {
			timer2 += Time.deltaTime;

			if (timer2 >= 0.7f) {
				text1.gameObject.SetActive (true);
			} if (timer2 >= 0.7f && Input.GetKey (KeyCode.Space)) {
				SceneManager.LoadScene ("MainGame");
			}
		}

	}
		

}
