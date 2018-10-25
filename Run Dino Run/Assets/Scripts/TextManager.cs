using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
	public Text healthMainText, scoreMainText, moneyMainText, healthPauseText, scorePauseText, moneyPauseText, scoreGameOverText, moneyGameOverText;
	GameObject player;
	Player playerS;
	private int health, score, money;
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		playerS = player.GetComponent<Player> ();
		TextsManager ();
	}

	void Update(){
		TextsManager ();
	}

	void GetValuesFromPlayer(){
		health = playerS.health;
		score = playerS.score;
		money = playerS.money;
	}

	void TextsManager(){
		GetValuesFromPlayer ();
		//Score text in main, pause and game over panel.
		//Health text in main, pause and game over panel.
		//Money text in main, pause and game over panel.
		scoreMainText.text = scorePauseText.text = scoreGameOverText.text = score.ToString ();
		healthMainText.text = healthPauseText.text = health.ToString ();
		moneyMainText.text = moneyPauseText.text = moneyGameOverText.text = money.ToString ();

	}
}
