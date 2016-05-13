using UnityEngine;
using System.Collections;

public class ChangeMusic : MonoBehaviour {

	public AudioClip level1_clip;
	public AudioClip level2_clip;

	private AudioSource source;

	void Awake () {
		source = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded (int level) {
		if (level == 1) {
			source.clip = level1_clip;
			source.Play ();
		}
		if (level == 2) {
			source.clip = level2_clip;
			source.Play ();
		}
	}
}
