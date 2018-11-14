using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundPanel : MonoBehaviour {
	public Text arkaPlan2priceText, arkaPlan3priceText;
	public Button forestBuyBtn, cityBuyBtn, selectButtonMountain, selectButtonForest, selectButtonCity;
	public Sprite forestPurchasedSpr, cityPurschasedSpr, interactableSwitchOff, interactableSwitchOn;
	bool forestPurchasedBool, cityPurchasedBool, mountainSelectedBool, forestSelectedBool, citySelectedBool;
	GameObject bossMainMenu;
	public GameObject forestPriceParent, cityPriceParent;
	string selectedBackground, arkaPlan1, arkaPlan2, arkaPlan3;
	int arkaPlan2price, arkaPlan3price;

	// Use this for initialization
	void Start () {
		bossMainMenu = GameObject.FindGameObjectWithTag ("_BossMainMenu");
		arkaPlan1 = bossMainMenu.GetComponent<bossOftheMainMenu> ().arkaPlan1;
		arkaPlan2 = bossMainMenu.GetComponent<bossOftheMainMenu> ().arkaPlan2;
		arkaPlan3 = bossMainMenu.GetComponent<bossOftheMainMenu> ().arkaPlan3;
		selectedBackground = PlayerPrefs.GetString ("arkaPlan", "0");
		if (selectedBackground == "0") {
			selectedBackground = PlayerPrefs.GetString("arkaPlan1Key");
			PlayerPrefs.SetString ("arkaPlan", selectedBackground);
		}
	}

	void Update(){
		isPurchased ();
		ButtonSettings ();
		TextSettings ();
		isThereMoneyEnough ();
		whichSelected ();
	}

	// Update is called once per frame
	void isPurchased () {
		
		if (PlayerPrefs.GetString (arkaPlan2) == "alindi") {
			forestPurchasedBool = true;
		} else {
			forestPurchasedBool = false;
		}

		if (PlayerPrefs.GetString (arkaPlan3) == "alindi") {
			cityPurchasedBool = true;
		} else {
			cityPurchasedBool = false;
		}
	}

	void ButtonSettings(){
		if (forestPurchasedBool && !selectButtonForest.gameObject.activeInHierarchy) {

				forestPriceParent.SetActive (false);
				Destroy (forestBuyBtn.GetComponent<Button> ());
				forestBuyBtn.GetComponent<Image> ().sprite = forestPurchasedSpr;
				selectButtonForest.gameObject.SetActive (true);

		}

		if (cityPurchasedBool && !selectButtonCity.gameObject.activeInHierarchy) {

				cityPriceParent.SetActive (false);
				Destroy (cityBuyBtn.GetComponent<Button> ());
				cityBuyBtn.GetComponent<Image> ().sprite = cityPurschasedSpr;
				selectButtonCity.gameObject.SetActive (true);

		}

		if (mountainSelectedBool) {
			selectButtonMountain.GetComponent<Image> ().sprite = interactableSwitchOn;
			selectButtonForest.GetComponent<Image> ().sprite = interactableSwitchOff;
			selectButtonCity.GetComponent<Image> ().sprite = interactableSwitchOff;
		} else if (forestSelectedBool) {
			selectButtonMountain.GetComponent<Image> ().sprite = interactableSwitchOff;
			selectButtonForest.GetComponent<Image> ().sprite = interactableSwitchOn;
			selectButtonCity.GetComponent<Image> ().sprite = interactableSwitchOff;
		} else if (citySelectedBool) {
			selectButtonMountain.GetComponent<Image> ().sprite = interactableSwitchOff;
			selectButtonForest.GetComponent<Image> ().sprite = interactableSwitchOff;
			selectButtonCity.GetComponent<Image> ().sprite = interactableSwitchOn;
		}
	}

	void TextSettings(){
		arkaPlan2price = PlayerPrefs.GetInt ("arkaPlan2Price");
		arkaPlan3price = PlayerPrefs.GetInt ("arkaPlan3Price");
		arkaPlan2priceText.text = arkaPlan2price.ToString ();
		arkaPlan3priceText.text = arkaPlan3price.ToString ();
	}

	void isThereMoneyEnough(){
		int money = PlayerPrefs.GetInt ("money");
		if (!forestPurchasedBool) {
			if (money >= arkaPlan2price) {
				forestBuyBtn.interactable = true;
				//forestBuyBtn.GetComponent<Image> ().sprite = forestBuyBtnDefault;
			} else {
				forestBuyBtn.interactable = false;
			}
		}

		if (!cityPurchasedBool) {
			if (money >= arkaPlan3price) {
				cityBuyBtn.interactable = true;
				//cityBuyBtn.GetComponent<Image> ().sprite = forestBuyBtnDefault;
			} else {
				cityBuyBtn.interactable = false;
			}
		}
	}

	void SaveMoney(int money){
		PlayerPrefs.SetInt ("money", money);
	}

	public void BuyButton(string arkaPlan){
		int money = PlayerPrefs.GetInt ("money");
		if (arkaPlan == arkaPlan2) {
			PlayerPrefs.SetString (arkaPlan2, "alindi");
			SaveMoney (money - arkaPlan2price);
		} else if (arkaPlan == arkaPlan3) {
			PlayerPrefs.SetString (arkaPlan3, "alindi");
			SaveMoney (money - arkaPlan3price);
		}
	}

	public void SelectButton(string arkaPlan){
		if (PlayerPrefs.GetString (arkaPlan) == "alindi") {
			PlayerPrefs.SetString ("arkaPlan", arkaPlan);
			selectedBackground = PlayerPrefs.GetString ("arkaPlan");
		}
	}

	void whichSelected(){
		if (selectedBackground == arkaPlan1) {
			mountainSelectedBool = true;
			forestSelectedBool = false;
			citySelectedBool = false;
		} else if (selectedBackground == arkaPlan2) {
			mountainSelectedBool = false;
			forestSelectedBool = true;
			citySelectedBool = false;
		} else if (selectedBackground == arkaPlan3) {
			mountainSelectedBool = false;
			forestSelectedBool = false;
			citySelectedBool = true;
		}

	}

}
