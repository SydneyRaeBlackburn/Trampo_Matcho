using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//private float rotationAmount = 10.0f;

	void Update() {
		transform.rotation = Quaternion.Euler (0, 0, (Mathf.PingPong (Time.time, 20f) - 10));
	}
}
