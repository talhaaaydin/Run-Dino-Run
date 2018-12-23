using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class audioScript : MonoBehaviour {
	AudioSource aSource;
	public AudioClip switchAudio, buttonAudio, feedAudio;
	public float switchVolume = 0.08f, buttonVolume = 0.08f, feedVolume = 0.08f;

	// Use this for initialization
	void Start () {
		aSource = GetComponent<AudioSource> ();
	}
	
	public void switchPlay(){
		aSource.clip = switchAudio;
		aSource.volume = switchVolume;
		aSource.Play ();
	}

	public void buttonPlay(){
		aSource.clip = buttonAudio;
		aSource.volume = buttonVolume;
		aSource.Play ();
	}

	public void feedPlay(){
		aSource.clip = feedAudio;
		aSource.volume = feedVolume;
		aSource.Play ();
	}
}
