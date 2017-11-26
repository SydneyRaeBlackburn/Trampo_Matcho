using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class imageSwitch : MonoBehaviour {

	public Image images;
	public Sprite[] sprites = new Sprite[9];

	private int spriteNumberOld;
	private int spriteNumberNew;
	private int numberOfSwitches;
	private bool restart;
	private bool continueOn;
	private bool nextLevel;
	private bool lose;
	private bool win;

	void Start() {
		images.sprite = sprites [8];
		numberOfSwitches = 0;
		RandomSpriteNumber ();
		restart = false;
		lose = false;
		win = false;
		nextLevel = true;
	}

	void Update () {
		if (GameObject.Find ("Trampoline").GetComponent<TrampoBounce> ().level == 30 && numberOfSwitches == 0)
			win = true;
		if (GameObject.Find ("Trampoline").GetComponent<TrampoBounce> ().entered == true && win == false){ 
			if (!nextLevel) {
				lose = true;
			} else {
				GameObject.Find ("Trampoline").GetComponent<TrampoBounce> ().level++;
				GameObject.Find ("Trampoline").GetComponent<TrampoBounce> ().levelText.text = "Level: " + 
					GameObject.Find ("Trampoline").GetComponent<TrampoBounce> ().level;
				SetSprite ();
				GameObject.Find ("Trampoline").GetComponent<TrampoBounce> ().entered = false;
				numberOfSwitches = GameObject.Find ("Trampoline").GetComponent<TrampoBounce> ().level;
				nextLevel = false;
			}
		}
		switch (spriteNumberOld) {
		case 0:
			if (Input.GetKey (KeyCode.DownArrow))
				SwitchHandler ();
			break;
		case 1:
			if (Input.GetKey (KeyCode.LeftArrow))
				SwitchHandler ();
			break;
		case 2:
			if (Input.GetKey (KeyCode.RightArrow))
				SwitchHandler ();
			break;
		case 3:
			if (Input.GetKey (KeyCode.UpArrow))
				SwitchHandler ();
			break;
		case 4:
			if (Input.GetKey (KeyCode.Alpha1) || Input.GetKey (KeyCode.Keypad1))
				SwitchHandler ();
			break;
		case 5:
			if (Input.GetKey (KeyCode.Alpha2) || Input.GetKey (KeyCode.Keypad2))
				SwitchHandler ();
			break;
		case 6:
			if (Input.GetKey (KeyCode.Alpha3) || Input.GetKey (KeyCode.Keypad3))
				SwitchHandler ();
			break;
		case 7:
			if (Input.GetKey (KeyCode.Space))
				SwitchHandler ();
			break;
		default:
			images.sprite = sprites [8];
			break;
		}

		if (lose) {
			GameObject.Find ("Trampoline").GetComponent<TrampoBounce> ().loseText.text = "You lose";
			GameObject.Find ("Trampoline").GetComponent<TrampoBounce> ().restartText.text = "Press 'R' for Restart";
			StartCoroutine (EndGame ());
			continueOn = true;
		}

		if (win) {
			GameObject.Find ("Trampoline").GetComponent<TrampoBounce> ().winText.text = "You win!";
			GameObject.Find ("Trampoline").GetComponent<TrampoBounce> ().restartText.text = "Press 'R' for Restart";
			StartCoroutine (EndGame ());
			continueOn = true;
		}

		if (continueOn) {
			if (Input.GetKeyDown (KeyCode.R))
				restart = true;
		}
	}

	private void SwitchHandler() {
		numberOfSwitches--;
		if (numberOfSwitches == 0) {
			spriteNumberOld = -1;
			nextLevel = true;
		} else
			SetSprite ();
	}

	private void SetSprite() {
		images.sprite = sprites [spriteNumberNew];
		spriteNumberOld = spriteNumberNew;
		RandomSpriteNumber ();
	}

	private void RandomSpriteNumber() {
		spriteNumberNew = UnityEngine.Random.Range (0,4);
		if (spriteNumberNew == spriteNumberOld) {
			RandomSpriteNumber ();
		}
	}

	IEnumerator EndGame () {
		if (lose || win) {
			yield return new WaitUntil (() => restart == true);
			SceneManager.LoadScene("Main", LoadSceneMode.Single);
		}
	}
}
