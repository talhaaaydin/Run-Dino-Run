using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyYourself : MonoBehaviour {

	public enum Orientation{
		Asteroid, Effect, AsteroidPattern
	};
	public Orientation senNesin;

	public float destroyLimitDistance;
	// Update is called once per frame
	void Update () {
		if (senNesin == Orientation.Asteroid) {
			DestroyAsteroid ();
		} else if (senNesin == Orientation.Effect) {
			DestroyEffect ();
		} else if (senNesin == Orientation.AsteroidPattern) {
			DestroyAsteroidPattern ();
		}
	}

	void DestroyAsteroid(){
		Transform player = GameObject.FindGameObjectWithTag ("Player").transform;
		float xFarki = transform.position.x - player.position.x;
		if (Vector2.Distance (transform.position, player.position) >= destroyLimitDistance && xFarki <= 0) {
			//puana ekleme yapılıyor.
			player.gameObject.GetComponent<Player>().score += 1;
			//puana ekleme yapıldı.
			Destroy (gameObject);
		}
	}

	void DestroyEffect(){
		ParticleSystem ps = GetComponent<ParticleSystem> ();
		if (!ps.isPlaying) {
			Destroy (gameObject);
		}
	}

	void DestroyAsteroidPattern(){
		string name = gameObject.name;
		GameObject other = GameObject.Find (name);
		if (other.gameObject != gameObject) {
			Destroy (gameObject);
		}
	}
}
