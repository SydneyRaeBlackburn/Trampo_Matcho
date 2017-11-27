﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trampoMatcho : MonoBehaviour {

	public Image images;
	public Sprite[] sprites = new Sprite[5];
	public AudioClip deathEffect;
	public AudioClip winEffect;
	public Text levelText;
	public Text winText;
	public Text loseText;
	public Text switchesLeftText;

	private bool nextLevel;
	private bool lose;
	private bool win;
	private int spriteNumberOld;
	private int spriteNumberNew;
	private int numberOfSwitches;

	public enum Direction { UP, LEFT, RIGHT, DOWN }

	void Start () {
		lose = false;
		win = false;
		nextLevel = true;
		images.sprite = sprites [4];
		numberOfSwitches = 0;
		RandomSpriteNumber ();
		levelText.text = "Level: ";
		winText.text = "";
		loseText.text = "";
		switchesLeftText.text = "Switches Left: " + GameManager.instance.level;
		StartCoroutine(UpdateSwitches());
	}

	void Update () {
		if ((nextLevel == true) && (GameObject.Find ("Trampoline").GetComponent<TrampoBounce> ().entered == true)) {
			GameManager.instance.level++;
			numberOfSwitches = GameManager.instance.level;
			levelText.text = "Level: " + GameManager.instance.level;
			switchesLeftText.text = "Switches Left: " + numberOfSwitches;
			SetSprite ();
			GameObject.Find ("Trampoline").GetComponent<TrampoBounce> ().entered = false;
			nextLevel = false;
		}
	}

	IEnumerator UpdateSwitches () {
		while (true) {
			// handle multi key presses
			if (inputHandler.GetStandardMoveMultiInputKeys ()) {
				yield return null;
				continue;
			}

			// up arrow was pressed
			if (inputHandler.GetStandardMoveUpDirection()) {
				yield return StartCoroutine (ImageSwitch (Direction.UP)); 
			}

			// left arrow was pressed
			if (inputHandler.GetStandardMoveLeftDirection ()) {
				yield return StartCoroutine (ImageSwitch (Direction.LEFT)); 
			}

			// down arrow was pressed
			if (inputHandler.GetStandardMoveDownDirection ()) {
				yield return StartCoroutine (ImageSwitch (Direction.DOWN)); 
			}

			// right arrow was pressed
			if (inputHandler.GetStandardMoveRightDirection ()) {
				yield return StartCoroutine (ImageSwitch (Direction.RIGHT)); 
			}

			if (GameManager.instance.level == 30 && numberOfSwitches == 0) {
				win = true;
				break;
			} else if (GameObject.Find ("Trampoline").GetComponent<TrampoBounce> ().entered == true && numberOfSwitches != 0) {
				lose = true;
				break;
			}

			yield return null;
		}

		if (win) {
			SoundManager.instance.PlaySingle (winEffect);
			winText.text = "You win!";
		} else if (lose) {
			loseText.text = "You lose";
			SoundManager.instance.PlaySingle (deathEffect);
		}
	}

	public IEnumerator ImageSwitch(Direction arrowPressed) {
		switch (arrowPressed) {
		case Direction.DOWN:
			if ((spriteNumberOld == 0) && (numberOfSwitches != 0))
				SwitchHandler ();
			break;
		case Direction.LEFT:
			if ((spriteNumberOld == 1)  && (numberOfSwitches != 0))
				SwitchHandler ();
			break;
		case Direction.RIGHT:
			if ((spriteNumberOld == 2) && (numberOfSwitches != 0))
				SwitchHandler ();
			break;
		case Direction.UP:
			if ((spriteNumberOld == 3) && (numberOfSwitches != 0))
				SwitchHandler ();
			break;
		}

		yield return null;
	}

	private void RandomSpriteNumber() {
		spriteNumberNew = UnityEngine.Random.Range (0,4);
		if (spriteNumberNew == spriteNumberOld) {
			RandomSpriteNumber ();
		}
	}

	private void SetSprite() {
		images.sprite = sprites [spriteNumberNew];
		spriteNumberOld = spriteNumberNew;
		RandomSpriteNumber ();
	}

	private void SwitchHandler() {
		numberOfSwitches--;
		switchesLeftText.text = "Switches Left: " + numberOfSwitches;
		if (numberOfSwitches <= 0) {
			images.sprite = sprites [4];
			nextLevel = true;
		} else
			SetSprite ();
	}
}
