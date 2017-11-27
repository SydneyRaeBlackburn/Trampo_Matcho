﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public int level = 0;

	public static GameManager Instance {
		get { return instance; }
	}

	private void Awake() {
		if ((instance != null) && (instance != this)) {
			Destroy (this.gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
	}
}

