using UnityEngine;
using System.Collections;

public class inputHandler {
	
	// handle multi Input
	public static bool GetStandardMoveMultiInputKeys() {
		// check UpArrow
		if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey (KeyCode.LeftArrow))  { return true; }
		if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey (KeyCode.DownArrow))  { return true; }
		if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey (KeyCode.RightArrow)) { return true; }

		// check LeftArrow
		if (Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.DownArrow))  { return true; }
		if (Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.RightArrow)) { return true; }

		// check DownArrow
		if (Input.GetKey (KeyCode.DownArrow) && Input.GetKey (KeyCode.RightArrow)) { return true; } 
		// RightArrow is resulted in the checks above

		return false;
	}

	// handle up
	public static bool GetStandardMoveUpDirection() {
		if (Input.GetKey(KeyCode.UpArrow)) { return true; }
		return false;
	}

	// handle left
	public static bool GetStandardMoveLeftDirection() {
		if (Input.GetKey(KeyCode.LeftArrow)) { return true; }
		return false;
	}

	// handle down
	public static bool GetStandardMoveDownDirection() {
		if (Input.GetKey(KeyCode.DownArrow)) { return true; }
		return false;
	}

	// handle right
	public static bool GetStandardMoveRightDirection() {
		if (Input.GetKey(KeyCode.RightArrow)) { return true; }
		return false;
	} 
}

