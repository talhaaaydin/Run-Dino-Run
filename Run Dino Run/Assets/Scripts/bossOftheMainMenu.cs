using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class bossOftheMainMenu : MonoBehaviour {
	string arkaPlan;
	public string arkaPlan1 = "mountain", arkaPlan2 = "forest", arkaPlan3 = "city", meteor1 = "asteroid", meteor2 = "basketball", meteor3 = "bird";
	public int wheatPrice = 30;
	int kacKereOynandi, money, bestScore, energy;
	public Text moneyText, bestScoreText, energyValue, wheatPriceText;
	public Slider energySlider, soundSlider;
	public AudioMixer aMixer;
	public Button MuteButton, feedButton, choosingBackgroundPanel;
	public Sprite MuteSprite, UnMuteSprite;
	public GameObject choosingBackground, marketPage;

	void Start () {
		StartSettings ();
		ValueSettings ();
	}
	
	// Update is called once per frame
	void Update () {
		//Eğer soundSlider en düşük seviyede değilse yani sessiz modda değilse, sessiz butonunun önüne sesi açık hoparlör resmi koy.
		if (soundSlider.value != soundSlider.minValue) {
			MuteButton.GetComponent<Image> ().sprite = UnMuteSprite;
		} else 
		{ // Eğer soundSlider en düşük seviyedeyse sessiz moddadır. O yüzden sessiz butonunun önüne sesi kapalı hoparlör resmi koy.
			MuteButton.GetComponent<Image> ().sprite = MuteSprite;
		}

		//Eğer enerji seviyesini belirleyen energySlider en yüksek seviyedeyse yani enerjimiz tam doluysa, besle butonunu tıklanamaz hale getir.
		//Aynı şeyi paramız, besleme bedeli veya buğday ücretinden düşükse yine yap ki parası olmayan buğday alamasın.
		if (energy == energySlider.maxValue  || money < wheatPrice) {
			feedButton.interactable = false;
		} else if (energy < energySlider.maxValue || money >= wheatPrice) 
		{ //Eğer paramız yeterli veya daha çoksa, veya enerjimiz tam dolu değilse besleme butonunu tıklanabilir hale getir.
			feedButton.interactable = true;
		}

		//Eğer enerjimiz en düşük seviyede ya da ondan daha düşükse ana ekrandaki play tuşu yani arka plan seçme tuşunu tıklanamaz hale getir.
		if (energy <= energySlider.minValue) {
			choosingBackgroundPanel.interactable = false;
		} else if(energy > energySlider.minValue) {
			//Eğer enerjimiz en düşük seviyenin üstünde herhangi bir seviyede ise play tuşu tıklanabilsin.
			choosingBackgroundPanel.interactable = true;
		}

		TextSettings ();
		ValueSettings ();
	}

	void TextSettings(){
		//Ana ekrandaki para, en yüksek skor, enerji ve buğday ücretini gösterecek olan Text lerin içini doldurur.
		moneyText.text = money.ToString ();
		bestScoreText.text = bestScore.ToString ();
		energyValue.text = energy.ToString ();
		wheatPriceText.text = wheatPrice.ToString ();
	}

	void ValueSettings(){
		//Kaç kere oynandı oyuna ilk başlandığında sıfır olarak döner çünkü kaç kere oynandı değeri ilk defa oyunda yenilince kaydedilir ve oyunda yenilgi yaşandığında
		//güncellenir.
		kacKereOynandi = PlayerPrefs.GetInt ("kacKereOynandi", 0);
		//Para yine oyuna ilk başlayan birisi için sıfır olarak başlar.
		money = PlayerPrefs.GetInt ("money", 0);
		//En yüksek skor oyuna ilk başlayan birisi için sıfır olarak başlar.
		bestScore = PlayerPrefs.GetInt ("bestScore", 0);

		//EnergySliderın değeri, bu gameobject içindeki enerji değeri PlayerPrefsten alınan enerji değerine eşitlenir.
		energySlider.value = energy = PlayerPrefs.GetInt ("energyValue");
		//Soundsliderın değeri de yine önceden belirlenmiş bir ses düzeyi yoksa 0 olarak başlar.
		float savedVolume = PlayerPrefs.GetFloat ("volumeParam", 0);
		soundSlider.value = savedVolume;
	}

	void StartSettings(){
		kacKereOynandi = PlayerPrefs.GetInt ("kacKereOynandi", 0);
		if (kacKereOynandi == 0) {
			//Eğer kaç kere oynandı değeri sıfırsa yani oyuncu oyunu yeni açmışsa
			//Arka plan keylerini PlayerPrefse atar ve kaydeder çünkü arka plan keyleri sadece bu sahnede kullanılmıyor.Bir değeri iki yerden değiştirmek yerine bu daha mantıklı.
			//Ve daha sonra PlayerPrefse arka plan isimlerinin karşısına alındı ve alınmadı durumları yazdırılır. Arka plan 1 için bu değer hep alındı olacaktır.
			//Ve daha sonra PlayerPrefse enerji değeri energySlider ın alabileceği en yüksek değer olarak belirlenir.
			PlayerPrefs.SetString ("arkaPlan1Key", arkaPlan1);
			PlayerPrefs.SetString ("arkaPlan2Key", arkaPlan2);
			PlayerPrefs.SetString ("arkaPlan3Key", arkaPlan3);
			PlayerPrefs.SetString (arkaPlan1, "alindi");
			PlayerPrefs.SetString (arkaPlan2, "alinmadi");
			PlayerPrefs.SetString (arkaPlan3, "alinmadi");
			PlayerPrefs.SetString ("meteor1Key", meteor1);
			PlayerPrefs.SetString ("meteor2Key", meteor2);
			PlayerPrefs.SetString ("meteor3Key", meteor3);
			PlayerPrefs.SetString (meteor1, "alindi");
			PlayerPrefs.SetString (meteor2, "alinmadi");
			PlayerPrefs.SetString (meteor3, "alinmadi");
			PlayerPrefs.SetString ("selectedMeteor", meteor1);
			PlayerPrefs.SetInt ("energyValue", Mathf.RoundToInt (energySlider.maxValue));
			PlayerPrefs.SetInt ("energyMinValue", Mathf.RoundToInt (energySlider.minValue));
		}
	}

	void SaveMoney(int money){
		PlayerPrefs.SetInt ("money", money);
	}

	void SaveEnergy(int energy){
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



	public void PlayButton(){
		SceneManager.LoadScene ("2GameScene");
	}

	public void MarketButton(){
		marketPage.SetActive (true);
	}

	public void CheatButton(string whichCheat){
		if (whichCheat == "deletePP") {
			PlayerPrefs.DeleteAll ();
			StartSettings ();
		} else if (whichCheat == "moneyFull") {
			SaveMoney (1000);
		} else if (whichCheat == "moneyZero") {
			SaveMoney (0);
		}
	}

	public void FeedButton(){
		SaveEnergy (energy + 1);
		SaveMoney (money - wheatPrice);
	}

}
