using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;
using UnityEngine.UI;

public class EventScript : MonoBehaviour {

	public GameObject bicycle;
	public GameObject eagle, school;
	public GameObject text1;
	public Text text2;
	public Text stageTimer;
	private float timer = 0.0f, timer2;
	public bool a = false, b = false ,c = false ,d = false ,e = false;
	private float speed;
	public int stageTime;
	//audio
	public AudioSource audio1,audio2,audio3;
	public AudioSource koukaon;


	void Start () {
		
		if (PlayerPrefs.GetInt ("level") == 2) {
			bicycle.gameObject.SetActive (false);
			eagle.gameObject.SetActive (true);
			bicycle = eagle;
			audio1.volume = 0.0f;
			audio2.volume = 0.7f;
		}
		if (PlayerPrefs.GetInt ("level") == 3) {
			bicycle.gameObject.SetActive (false);
			school.gameObject.SetActive (true);
			d = true;
			PlayerPrefs.SetFloat ("point",PlayerPrefs.GetFloat("point") * 1.5f);
			audio1.volume = 0.0f;
			audio3.volume = 0.7f;
		}

	}


	void Update () {
		timer += Time.deltaTime;


		if (PlayerPrefs.GetInt ("level") <= 2) {//-------------------------------------------
		
			stageTimer.text = "残り" + (int)(stageTime - timer) + "秒";

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
				} else {
					a = false;
				}
			}

			if (a == false && timer > 5.0f) {

				text2.gameObject.SetActive (true);
				bicycle.transform.position = new Vector3 (bicycle.transform.position.x + Random.Range (-0.01f, 0.01f), bicycle.transform.position.y, bicycle.transform.position.z);

				if (Input.GetKeyDown (KeyCode.Space)) {
					bicycle.transform.position = new Vector3 (bicycle.transform.position.x, bicycle.transform.position.y, bicycle.transform.position.z - 0.1f);
					koukaon.Play ();
					//text moving
					if (e == false) {
						text2.transform.position = new Vector3 (text2.transform.position.x, text2.transform.position.y - 10.0f, text2.transform.position.z);
						e = true;
					} else {
						text2.transform.position = new Vector3 (text2.transform.position.x, text2.transform.position.y + 10.0f, text2.transform.position.z);
						e = false;
					}
				}
				if (bicycle.transform.position.z <= this.transform.position.z + 0.5f) {

					timer2 += Time.deltaTime;
					text2.text = "ひったくり犯を捕まえた！\n次のステージへ";
					c = true;
					stageTimer.gameObject.SetActive (false);

					if (timer2 >= 4.0f) {
						PlayerPrefs.SetInt ("level", PlayerPrefs.GetInt ("level") + 1);
						SceneManager.LoadScene ("MainGame");
					}
				}
			}

			if (stageTime - (int)timer <= 0 && c == false) {
				bicycle.transform.position = new Vector3 (bicycle.transform.position.x, bicycle.transform.position.y, bicycle.transform.position.z + 2 * speed);
				text2.text = "ひったくり犯に\n逃げられてしまった";
				stageTimer.gameObject.SetActive (false);

				if (stageTime - (int)timer <= -4) {
					SceneManager.LoadScene ("GameOver");
				}
			}

		}//----------------------------------------------------------------

		if (d == true) {
			if (timer >= 2.0f) {
				text2.text = "学校が見えたけど\nまずい、学校に間に合わない！";
				text2.gameObject.SetActive (true);
			}
			stageTimer.text = "チャイムまで" + (int)(stageTime / 2.0f - timer) + "秒";
			if ((int)(stageTime / 2.0f - timer) <= 0) {
				stageTimer.text = "遅刻確定。罪が1.5倍になった。";
			}
			if ((int)(stageTime / 2.0f - timer) <= -4) {
				PlayerPrefs.SetInt ("level",4);
				SceneManager.LoadScene ("GameOver");
			}
		}

	}
}
