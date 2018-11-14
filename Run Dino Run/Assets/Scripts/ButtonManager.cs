using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public AudioMixer aMixer;
	public Button MuteButton, TryAgainButton;
	public Text energyGameOverText;
	public GameObject GamePanel, PausePanel, GameOverPanel;
	public Sprite MuteSprite, UnMuteSprite;
	public Slider soundSlider;
	GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		float savedVolume = PlayerPrefs.GetFloat ("volumeParam", 0);
		soundSlider.value = savedVolume;
	}

	void Update(){
		if (soundSlider.value != soundSlider.minValue) {
			MuteButton.GetComponent<Image> ().sprite = UnMuteSprite;
		} else {
			MuteButton.GetComponent<Image> ().sprite = MuteSprite;
		}
	}

	public void Pause(){
		GamePanel.SetActive (false);
		PausePanel.SetActive (true);
		GameOverPanel.SetActive (false);
		TimeScaleChange (0);
	}

	void Mute(){
		MuteButton.GetComponent<Image> ().sprite = MuteSprite;
		PlayerPrefs.SetFloat ("volumeParam", soundSlider.minValue);
		soundSlider.value = PlayerPrefs.GetFloat ("volumeParam",0);
		SetVolume (soundSlider.value);
	}

	void UnMute(){
		MuteButton.GetComponent<Image> ().sprite = UnMuteSprite;
		PlayerPrefs.SetFloat ("volumeParam", 0);
		soundSlider.value = PlayerPrefs.GetFloat ("volumeParam",0);
		SetVolume (soundSlider.value);
	}

	public void SoundControl(){
		if (PlayerPrefs.GetFloat("volumeParam",0) == soundSlider.minValue) {
			UnMute ();
		} else {
			Mute ();
		}
	}

	public void SetVolume(float volume){
		aMixer.SetFloat ("volumeParam", volume);
		PlayerPrefs.SetFloat ("volumeParam", volume);
	}

	void TryAgainButtonInteractable(){
		int energyValue = PlayerPrefs.GetInt ("energyValue");
		int energyMinValue = PlayerPrefs.GetInt ("energyMinValue");
		if (energyValue <= energyMinValue) {
			TryAgainButton.interactable = false;
		} else {
			TryAgainButton.interactable = true;
		}
	}

	public void TryAgain(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void Resume(){
		GamePanel.SetActive (true);
		PausePanel.SetActive (false);
		GameOverPanel.SetActive (false);
		TimeScaleChange (1);
	}

	public void GameOver(){
		GamePanel.SetActive (false);
		PausePanel.SetActive (false);
		GameOverPanel.SetActive (true);
		TimeScaleChange (0);
		PlayerPrefs.SetInt ("kacKereOynandi", (PlayerPrefs.GetInt ("kacKereOynandi", 0) + 1));
		PlayerPrefs.SetInt ("energyValue", (PlayerPrefs.GetInt ("energyValue") - 1));
		energyGameOverText.text = PlayerPrefs.GetInt ("energyValue").ToString();
		TryAgainButtonInteractable ();
		PlayerPrefs.SetInt ("money", player.GetComponent<Player> ().money);
		int kayitliScore = PlayerPrefs.GetInt ("bestScore", 0);
		if (player.GetComponent<Player> ().score > kayitliScore) {
			PlayerPrefs.SetInt ("bestScore", player.GetComponent<Player> ().score);
		}
	}

	public void Exit(){
		SceneManager.LoadScene ("1MainScene");
	}

	void TimeScaleChange(float timeScale){
		Time.timeScale = timeScale;
	}
}
