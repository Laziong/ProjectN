using UnityEngine;
using System.Collections;

public class ClickSound : MonoBehaviour {

	private AudioSource click;
	private AudioSource unclick;

	// Use this for initialization
	void Start () {
		AudioSource[] audiosources = GetComponents<AudioSource> ();
		click = audiosources [0];
		unclick = audiosources [1];
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			click.PlayOneShot(click.clip);
		}
		if (Input.GetMouseButtonDown (1)) {
			unclick.PlayOneShot(unclick.clip);
		}
	}
}
