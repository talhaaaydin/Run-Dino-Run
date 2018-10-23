using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
	public GameObject Asteroid;
	// Use this for initialization
	void Start () {
		Instantiate (Asteroid, transform.position, Quaternion.identity);
	}

}
