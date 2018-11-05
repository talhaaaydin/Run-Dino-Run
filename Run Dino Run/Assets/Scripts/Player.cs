using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	Vector2 targetPos;
	public float yChangingValue, speed, maxHigh, minHigh, scoreToMoneyMultiple;

	public int health, score, money;
	public GameObject playerEffect, ButtonManager;
	private ShakeEffect shake;

	void Start(){
		money = PlayerPrefs.GetInt ("money", 0);
		targetPos = transform.position;
		score = 0;
	}

	// Update is called once per frame
	void Update () {
		healthControl ();
		YChangingKeyboard ();
	}

	void healthControl(){
		GameObject buttonManager = GameObject.FindGameObjectWithTag ("ButtonManager");
		if (health <= 0 && !buttonManager.GetComponent<ButtonManager>().GameOverPanel.activeInHierarchy) {
			ButtonManager.GetComponent<ButtonManager> ().GameOver ();
		}
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

}
