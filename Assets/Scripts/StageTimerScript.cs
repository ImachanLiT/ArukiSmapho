using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageTimerScript : MonoBehaviour {
	public float stageTimer;
	private float stageTime;
	public Text levelLabel;
	public Text ToNextText;

	void Start () {
		stageTime = stageTimer;
		levelLabel.gameObject.SetActive (true);
		levelLabel.text = "Level " + PlayerPrefs.GetInt ("level");
		if (PlayerPrefs.GetInt ("level") == 3) {
			levelLabel.text += " \nFinal Stage";
		}
	}

	void Update () {

		stageTimer -= Time.deltaTime;
		this.GetComponent<Text> ().text = "次のステージまで\n" + stageTimer.ToString ("F0") + "秒";
		if (stageTimer <= 0.0f) {
			SceneManager.LoadScene ("Event");
		}

		if (stageTime - 4.0f >= stageTimer) {
			levelLabel.gameObject.SetActive (false);
		}

		if (stageTimer <= 5.0f) {
			ToNextText.gameObject.SetActive (true);
		}
			

	}


	
}