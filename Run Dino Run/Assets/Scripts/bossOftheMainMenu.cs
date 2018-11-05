using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class bossOftheMainMenu : MonoBehaviour {
	string arkaPlan;
	public string arkaPlan1 = "mountain", arkaPlan2 = "forest", arkaPlan3 = "city";
	public int wheatPrice = 30;
	public Image Imagebg1, Imagebg2, lockbg2, Imagebg3, lockbg3;
	int kacKereOynandi, money, bestScore, energy;
	public Text moneyText, bestScoreText, energyValue, wheatPriceText;
	public Slider energySlider, soundSlider;
	public AudioMixer aMixer;
	public Button MuteButton, feedButton, choosingBackgroundPanel;
	public Sprite MuteSprite, UnMuteSprite;
	public GameObject choosingBackground, marketPage;

	void Start () {
		ValueSettings ();
	}
	
	// Update is called once per frame
	void Update () {

		if (soundSlider.value != soundSlider.minValue) {
			MuteButton.GetComponent<Image> ().sprite = UnMuteSprite;
		} else {
			MuteButton.GetComponent<Image> ().sprite = MuteSprite;
		}

		if (energy == energySlider.maxValue) {
			feedButton.interactable = false;
		} else if (energy < energySlider.maxValue) {
			feedButton.interactable = true;
		}

		if (energy <= energySlider.minValue) {
			choosingBackgroundPanel.interactable = false;
		} else if(energy > energySlider.minValue) {
			choosingBackgroundPanel.interactable = true;
		}

		TextSettings ();
		ValueSettings ();
		TikImageAorD ();
	}

	void TextSettings(){
		moneyText.text = money.ToString ();
		bestScoreText.text = bestScore.ToString ();
		energyValue.text = energy.ToString ();
		wheatPriceText.text = wheatPrice.ToString ();
	}

	void ValueSettings(){
		kacKereOynandi = PlayerPrefs.GetInt ("kacKereOynandi", 0);
		money = PlayerPrefs.GetInt ("money", 0);
		bestScore = PlayerPrefs.GetInt ("bestScore", 0);
		if (kacKereOynandi == 0) {
			PlayerPrefs.SetString ("arkaPlan1Key", arkaPlan1);
			PlayerPrefs.SetString ("arkaPlan2Key", arkaPlan2);
			PlayerPrefs.SetString ("arkaPlan3Key", arkaPlan3);
			PlayerPrefs.SetString (arkaPlan1, "alindi");
			PlayerPrefs.SetString (arkaPlan2, "alinmadi");
			PlayerPrefs.SetString (arkaPlan3, "alinmadi");
			PlayerPrefs.SetInt ("energyValue", Mathf.RoundToInt (energySlider.maxValue));
		}
		energy = PlayerPrefs.GetInt ("energyValue");
		energySlider.value = energy;
		float savedVolume = PlayerPrefs.GetFloat ("volumeParam", 0);
		soundSlider.value = savedVolume;
	}

	void SaveMoney(int money){
		PlayerPrefs.SetInt ("money", money);
	}

	void SaveEnery(int energy){
		PlayerPrefs.SetInt ("energyValue", energy);
	}

	void SliderSetting(){
		energySlider.value = energy;
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

	public void ChooseBackground(string backgroundName){
		if (PlayerPrefs.GetString (backgroundName) == "alindi") {
			PlayerPrefs.SetString ("arkaPlan", backgroundName);
			arkaPlan = PlayerPrefs.GetString ("arkaPlan");
		}
	}

	public void TikImageAorD(){
		arkaPlan = PlayerPrefs.GetString ("arkaPlan", "0");
		if (arkaPlan == "0") {
			arkaPlan = arkaPlan1;
			PlayerPrefs.SetString ("arkaPlan", arkaPlan1);
		}
		arkaPlan = PlayerPrefs.GetString ("arkaPlan");
		if (arkaPlan == arkaPlan1) {
			Imagebg1.gameObject.SetActive (true);
			Imagebg2.gameObject.SetActive (false);
			Imagebg3.gameObject.SetActive (false);
		}else if (arkaPlan == arkaPlan2) {
			Imagebg1.gameObject.SetActive (false);
			Imagebg2.gameObject.SetActive (true);
			Imagebg3.gameObject.SetActive (false);
		}else if (arkaPlan == arkaPlan3) {
			Imagebg1.gameObject.SetActive (false);
			Imagebg2.gameObject.SetActive (false);
			Imagebg3.gameObject.SetActive (true);
		}

		if (PlayerPrefs.GetString (arkaPlan2) == "alinmadi") {
			lockbg2.gameObject.SetActive (true);
		} else {
			lockbg2.gameObject.SetActive (false);
		}

		if (PlayerPrefs.GetString (arkaPlan3) == "alinmadi") {
			lockbg3.gameObject.SetActive (true);
		} else {
			lockbg3.gameObject.SetActive (false);
		}

	}

	public void PlayButton(){
		SceneManager.LoadScene ("2GameScene");
	}

	public void MarketButton(){
		marketPage.SetActive (true);
	}

	public void DeletePlayerPrefs(){
		PlayerPrefs.DeleteAll ();
	}

	public void FeedButton(){
		if (money >= wheatPrice) {
			SaveEnery (energy + 1);
			SaveMoney (money - wheatPrice);
		}
	}

}
