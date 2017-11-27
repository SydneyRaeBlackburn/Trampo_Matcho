using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float speed = 10.0f;

	void Update() {
		transform.rotation = Quaternion.Euler (0, 0, (Mathf.PingPong (Time.time * speed, 20f) - 10));
	}
}
