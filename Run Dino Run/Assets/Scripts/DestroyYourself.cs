using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyYourself : MonoBehaviour {

	public enum Orientation{
		Asteroid, AsteroidPattern
	};
	public Orientation senNesin;

	public float destroyLimitDistance;
	// Update is called once per frame
	void Update () {
		if (senNesin == Orientation.Asteroid) {
			DestroyAsteroid ();
		} else if (senNesin == Orientation.AsteroidPattern) {
			DestroyAsteroidPattern ();
		}
	}

	void DestroyAsteroid(){
		Transform player = GameObject.FindGameObjectWithTag ("Player").transform;
		float xFarki = transform.position.x - player.position.x;
		if (Mathf.Abs(xFarki) >= destroyLimitDistance && xFarki <= 0) {
			//puana ekleme yapılıyor.
			player.gameObject.GetComponent<Player>().score += 1;
			player.gameObject.GetComponent<Player> ().money += Mathf.RoundToInt(player.gameObject.GetComponent<Player> ().scoreToMoneyMultiple);
			//puana ekleme yapıldı.
			Destroy (gameObject);
		}
	}

	void DestroyAsteroidPattern(){
		string name = gameObject.name;
		GameObject pattern = GameObject.Find (name);
		if (pattern != gameObject) {
			Destroy (gameObject);
		}
	}

}
