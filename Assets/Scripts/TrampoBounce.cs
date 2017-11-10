using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampoBounce : MonoBehaviour {

	public GameObject player;

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Player") {
			Debug.Log ("True");
			player.transform.position = new Vector2 (transform.position.x, 0f);
		}
	}
}
