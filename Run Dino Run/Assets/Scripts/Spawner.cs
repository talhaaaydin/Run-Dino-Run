using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] AsteroidPattern;

	private float timeBtwSpawn;
	public float startTimeBtwSpawn;
	public float decreaseTime;
	public float minTimeBtwSpawn;

	void Update(){
		if (timeBtwSpawn <= 0) {
			int rand = Random.Range (0, AsteroidPattern.Length);
			Instantiate (AsteroidPattern[rand], transform.position, Quaternion.identity);
			timeBtwSpawn = startTimeBtwSpawn;
			if (startTimeBtwSpawn > minTimeBtwSpawn) {
				startTimeBtwSpawn -= decreaseTime;
			}
		} else {
			timeBtwSpawn -= Time.deltaTime;
		}
	}
}
