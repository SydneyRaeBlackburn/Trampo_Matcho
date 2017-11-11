using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrampoScroll: MonoBehaviour
{
	public ScrollRect myScrollRect;

	private float scroll = .01f;

	void Start() {
		myScrollRect.horizontalNormalizedPosition = -2.6f;
	}

	void Update() {
		myScrollRect.horizontalNormalizedPosition = myScrollRect.horizontalNormalizedPosition + scroll;
	}
}
