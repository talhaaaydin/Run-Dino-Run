using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	Vector2 targetPos;
	public float yChangingValue;
	public float speed;
	public float maxHigh, minHigh;

	public int health, score;
	public GameObject playerEffect;
	private ShakeEffect shake;
	public Text healthText, scoreText;

	void Start(){
		targetPos = transform.position;
		score = 0;
	}

	// Update is called once per frame
	void Update () {
		healthControl ();
		scoreControl ();
		YChangingKeyboard ();
		ShootChick ();
	}

	void healthControl(){
		healthText.text = health.ToString ();
		if (health <= 0) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	void scoreControl(){
		scoreText.text = score.ToString ();

	}

	void ApplyEffect(){
		shake = GameObject.FindGameObjectWithTag ("ShakeEffect").GetComponent<ShakeEffect> ();
		shake.CameraShake ();
		Instantiate (playerEffect, transform.position, Quaternion.identity);
	}

	void YChangingKeyboard(){

		if (Input.GetKeyDown (KeyCode.UpArrow) && transform.position.y < maxHigh) {
			targetPos = new Vector2 (transform.position.x, transform.position.y + yChangingValue);
			ApplyEffect ();
		} else if (Input.GetKeyDown (KeyCode.DownArrow) && transform.position.y > minHigh) {
			targetPos = new Vector2 (transform.position.x, transform.position.y - yChangingValue);
			ApplyEffect();
		}

		transform.position = Vector2.MoveTowards (transform.position, targetPos, speed * Time.deltaTime);

	}

	public void TouchAndMouseUp(){

		if (transform.position.y < maxHigh) {
			targetPos = new Vector2 (transform.position.x, transform.position.y + yChangingValue);
			ApplyEffect ();
		}
		transform.position = Vector2.MoveTowards (transform.position, targetPos, speed * Time.deltaTime);

	}
	public void TouchAndMouseDown(){

		if (transform.position.y > minHigh) {
			targetPos = new Vector2 (transform.position.x, transform.position.y - yChangingValue);
			ApplyEffect ();
		}
		transform.position = Vector2.MoveTowards (transform.position, targetPos, speed * Time.deltaTime);

	}

	void ShootChick(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Animator> ().SetTrigger ("shootChick");
		}
	}
}
