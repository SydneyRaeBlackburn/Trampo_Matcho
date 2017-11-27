using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrampoBounce : MonoBehaviour {
	
	public bool entered = false;
	public AudioClip jumpEffect;

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Player") {
			SoundManager.instance.PlaySingle (jumpEffect);
			entered = true;
		}
	}
}

