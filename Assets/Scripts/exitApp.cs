using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitApp : MonoBehaviour {

	public void ExitApp() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		Debug.Log ("Unity Editor");
		#else
		Application.Quit();
		Debug.Log ("Quit");
		#endif
	}
}
