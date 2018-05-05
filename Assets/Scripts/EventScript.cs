using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;
using UnityEngine.UI;

public class EventScript : MonoBehaviour {

	public GameObject bicycle;
	public GameObject eagle;
	public GameObject text1;
	public Text text2;
	private float timer = 0.0f, timer2;
	public bool a = false, b = false;
	private float speed;


	void Start () {
		
		if (PlayerPrefs.GetInt ("level") == 2) {
			bicycle.gameObject.SetActive (false);
			eagle.gameObject.SetActive (true);
			bicycle = eagle;
		}
	}


	void Update () {
		timer += Time.deltaTime;

		if (timer > 3.0f && b == false) {
			text1.gameObject.SetActive (true);
		}
		if (timer > 5.0f && b == false) {
			a = true;
			text1.gameObject.SetActive (false);
			b = true;
		}

		if (a == true) {
			if (bicycle.transform.position.z <= -2.0f) {
				speed = Time.deltaTime * 2.0f;
				bicycle.transform.position = new Vector3 (bicycle.transform.position.x, bicycle.transform.position.y, bicycle.transform.position.z + speed);
				if (PlayerPrefs.GetInt ("level") == 2 && bicycle.transform.position.y >= 0.8f) {
					bicycle.transform.position = new Vector3 (bicycle.transform.position.x, bicycle.transform.position.y - speed, bicycle.transform.position.z);
				}
				text2.gameObject.SetActive (true);
			} else {
				a = false;
			}
		}

		if (a == false && timer > 5.0f) {

			bicycle.transform.position = new Vector3 (bicycle.transform.position.x + Random.Range(-0.01f,0.01f), bicycle.transform.position.y, bicycle.transform.position.z);

			if (Input.GetKeyDown (KeyCode.Space)) {
				bicycle.transform.position = new Vector3 (bicycle.transform.position.x, bicycle.transform.position.y, bicycle.transform.position.z - 0.1f);

			}
			if (bicycle.transform.position.z <= this.transform.position.z + 0.5f) {

				timer2 += Time.deltaTime;
					text2.text = "ひったくり犯を捕まえた！\n次のステージへ";
				if (timer2 >= 4.0f) {
					PlayerPrefs.SetInt ("level", PlayerPrefs.GetInt ("level") + 1);
					SceneManager.LoadScene ("MainGame");
				}
			}
		}

	}
}
