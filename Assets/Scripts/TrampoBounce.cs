using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrampoBounce : MonoBehaviour {

	public GameObject player;
	public Text timerText;
	public Text levelText;

	private int level = 1;
	private float timeElapsed = 0.0f;
	private float timer = 0.0f;
	private float timerStart = 0.0f;

	void Start () {
		timerText.text = "Time Elapsed: " + timeElapsed;
		levelText.text = "Level: " + level;
	}

	void Update () {
		timer += Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Player") {
			Debug.Log ("True");
			timeElapsed = timer - timerStart;
			timerText.text = "Time Elapsed: " + timeElapsed;
			timerStart = timer;
			level += 1;
			levelText.text = "Level: " + level;
		}
	}
}
