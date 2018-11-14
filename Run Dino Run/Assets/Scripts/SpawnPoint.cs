using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
	public GameObject Asteroid, Basketball, Bird;
	// Use this for initialization
	void Start () {
		string MeteorValue1 = PlayerPrefs.GetString ("meteor1Key");
		string MeteorValue2 = PlayerPrefs.GetString ("meteor2Key");
		string MeteorValue3 = PlayerPrefs.GetString ("meteor3Key");
		string Meteor = PlayerPrefs.GetString ("selectedMeteor");

		if (Meteor == MeteorValue1) {
			Instantiate (Asteroid, transform.position, Quaternion.identity);
		} else if (Meteor == MeteorValue2) {
			Instantiate (Basketball, transform.position, Quaternion.identity);
		} else if (Meteor == MeteorValue3) {
			Instantiate (Bird, transform.position, Quaternion.identity);
		}
	}

}
