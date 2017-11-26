using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrampoBounce : MonoBehaviour {

	public Text levelText;
	public Text winText;
	public Text loseText;
	public Text restartText;
	public int level = 0;
	public bool entered = false;
	public AudioClip jumpEffect;

	void Start () {
		levelText.text = "Level: " + level;
		winText.text = "";
		loseText.text = "";
		restartText.text = "";
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Player") {
			SoundManager.instance.PlaySingle (jumpEffect);
			entered = true;
		}
	}
}

