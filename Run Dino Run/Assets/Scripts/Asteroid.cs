using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	public int healthDamage = 1;
	public int scoreDamage = 2;
	public float speed;
	public GameObject effect;

	void Update(){
		transform.Translate (Vector2.left * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			Instantiate (effect, transform.position, Quaternion.identity);
			other.GetComponent<Player> ().health -= healthDamage;
			other.GetComponent<Player> ().score -= scoreDamage;
			Destroy (gameObject);
		}
	}


}
