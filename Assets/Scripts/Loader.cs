using UnityEngine;
using System.Collections;


public class Loader : MonoBehaviour 
{
	// Code taken from a unity tutorial about creating a sound and game manager

	public GameObject soundManager;         //SoundManager prefab to instantiate.


	void Awake ()
	{
		//Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
		if (SoundManager.instance == null)

			//Instantiate SoundManager prefab
			Instantiate(soundManager);
	}
}
