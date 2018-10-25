using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public AudioMixer aMixer;
	public Button MuteButton;
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
		PlayerPrefs.SetInt ("money", player.GetComponent<Player> ().money);
	}

	public void Exit(){
		Application.Quit ();
	}

	void TimeScaleChange(float timeScale){
		Time.timeScale = timeScale;
	}
}
