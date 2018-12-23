using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorPanel : MonoBehaviour {
	public Text meteor2priceText, meteor3priceText, meteor4priceText;
	public Button basketballBuyBtn, birdBuyBtn, spaceShipBuyBtn, selectButtonAsteroid, selectButtonBasketball, selectButtonBird, selectButtonSpaceShip;
	public Sprite basketballPurchasedSpr, birdPurschasedSpr, spaceShipPurschasedSpr, interactableSwitchOff, interactableSwitchOn;
	bool basketballPurchasedBool, birdPurchasedBool, spaceShipPurchasedBool, asteroidSelectedBool, basketballSelectedBool, birdSelectedBool, spaceShipSelectedBool;
	GameObject bossMainMenu;
	public GameObject basketballPriceParent, birdPriceParent, spaceShipPriceParent;
	string selectedMeteor, meteor1, meteor2, meteor3, meteor4;
	int meteor2price, meteor3price, meteor4price;

	// Use this for initialization
	void Start () {
		bossMainMenu = GameObject.FindGameObjectWithTag ("_BossMainMenu");
		meteor1 = bossMainMenu.GetComponent<bossOftheMainMenu> ().meteor1;
		meteor2 = bossMainMenu.GetComponent<bossOftheMainMenu> ().meteor2;
		meteor3 = bossMainMenu.GetComponent<bossOftheMainMenu> ().meteor3;
		meteor4 = bossMainMenu.GetComponent<bossOftheMainMenu> ().meteor4;
		selectedMeteor = PlayerPrefs.GetString ("selectedMeteor", "0");
		if (selectedMeteor == "0") {
			selectedMeteor = PlayerPrefs.GetString("meteor1Key");
			PlayerPrefs.SetString ("selectedMeteor", selectedMeteor);
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

		if (PlayerPrefs.GetString (meteor2) == "alindi") {
			basketballPurchasedBool = true;
		} else {
			basketballPurchasedBool = false;
		}


		if (PlayerPrefs.GetString (meteor3) == "alindi") {
			birdPurchasedBool = true;
		} else {
			birdPurchasedBool = false;
		}

		if (PlayerPrefs.GetString (meteor4) == "alindi") {
			spaceShipPurchasedBool = true;
		} else {
			spaceShipPurchasedBool = false;
		}

	}

	void ButtonSettings(){
		if (basketballPurchasedBool && !selectButtonBasketball.gameObject.activeInHierarchy) {

			basketballPriceParent.SetActive (false);
			Destroy (basketballBuyBtn.GetComponent<Button> ());
			basketballBuyBtn.GetComponent<Image> ().sprite = basketballPurchasedSpr;
			selectButtonBasketball.gameObject.SetActive (true);

		}


		if (birdPurchasedBool && !selectButtonBird.gameObject.activeInHierarchy) {

			birdPriceParent.SetActive (false);
			Destroy (birdBuyBtn.GetComponent<Button> ());
			birdBuyBtn.GetComponent<Image> ().sprite = birdPurschasedSpr;
			selectButtonBird.gameObject.SetActive (true);

		}

		if (spaceShipPurchasedBool && !selectButtonSpaceShip.gameObject.activeInHierarchy) {

			spaceShipPriceParent.SetActive (false);
			Destroy (spaceShipBuyBtn.GetComponent<Button> ());
			spaceShipBuyBtn.GetComponent<Image> ().sprite = spaceShipPurschasedSpr;
			selectButtonSpaceShip.gameObject.SetActive (true);

		}


		if (asteroidSelectedBool) {
			selectButtonAsteroid.GetComponent<Image> ().sprite = interactableSwitchOn;
			selectButtonBasketball.GetComponent<Image> ().sprite = interactableSwitchOff;
			selectButtonBird.GetComponent<Image> ().sprite = interactableSwitchOff;
			selectButtonSpaceShip.GetComponent<Image> ().sprite = interactableSwitchOff;
		} else if (basketballSelectedBool) {
			selectButtonAsteroid.GetComponent<Image> ().sprite = interactableSwitchOff;
			selectButtonBasketball.GetComponent<Image> ().sprite = interactableSwitchOn;
			selectButtonBird.GetComponent<Image> ().sprite = interactableSwitchOff;
			selectButtonSpaceShip.GetComponent<Image> ().sprite = interactableSwitchOff;
		} else if (birdSelectedBool) {
			selectButtonAsteroid.GetComponent<Image> ().sprite = interactableSwitchOff;
			selectButtonBasketball.GetComponent<Image> ().sprite = interactableSwitchOff;
			selectButtonBird.GetComponent<Image> ().sprite = interactableSwitchOn;
			selectButtonSpaceShip.GetComponent<Image> ().sprite = interactableSwitchOff;
		} else if (spaceShipSelectedBool) {
			selectButtonAsteroid.GetComponent<Image> ().sprite = interactableSwitchOff;
			selectButtonBasketball.GetComponent<Image> ().sprite = interactableSwitchOff;
			selectButtonBird.GetComponent<Image> ().sprite = interactableSwitchOff;
			selectButtonSpaceShip.GetComponent<Image> ().sprite = interactableSwitchOn;
		}
	}

	void TextSettings(){
		meteor2price = PlayerPrefs.GetInt ("meteor2Price");
		meteor3price = PlayerPrefs.GetInt ("meteor3Price");
		meteor4price = PlayerPrefs.GetInt ("meteor4Price");
		meteor2priceText.text = meteor2price.ToString ();
		meteor3priceText.text = meteor3price.ToString ();
		meteor4priceText.text = meteor4price.ToString ();
	}

	void isThereMoneyEnough(){
		int money = PlayerPrefs.GetInt ("money");
		if (!basketballPurchasedBool) {
			if (money >= meteor2price) {
				basketballBuyBtn.interactable = true;
				//forestBuyBtn.GetComponent<Image> ().sprite = forestBuyBtnDefault;
			} else {
				basketballBuyBtn.interactable = false;
			}
		}

		if (!birdPurchasedBool) {
			if (money >= meteor3price) {
				birdBuyBtn.interactable = true;
				//cityBuyBtn.GetComponent<Image> ().sprite = forestBuyBtnDefault;
			} else {
				birdBuyBtn.interactable = false;
			}
		}

		if (!spaceShipPurchasedBool) {
			if (money >= meteor4price) {
				spaceShipBuyBtn.interactable = true;
				//cityBuyBtn.GetComponent<Image> ().sprite = forestBuyBtnDefault;
			} else {
				spaceShipBuyBtn.interactable = false;
			}
		}
	}

	void SaveMoney(int money){
		PlayerPrefs.SetInt ("money", money);
	}

	public void BuyButton(string meteor){
		int money = PlayerPrefs.GetInt ("money");
		if (meteor == meteor2) {
			PlayerPrefs.SetString (meteor2, "alindi");
			SaveMoney (money - meteor2price);
		} else if (meteor == meteor3) {
			PlayerPrefs.SetString (meteor3, "alindi");
			SaveMoney (money - meteor3price);
		} else if (meteor == meteor4) {
			PlayerPrefs.SetString (meteor4, "alindi");
			SaveMoney (money - meteor4price);
		}
	}

	public void SelectButton(string meteor){
		if (PlayerPrefs.GetString (meteor) == "alindi") {
			PlayerPrefs.SetString ("selectedMeteor", meteor);
			selectedMeteor = PlayerPrefs.GetString ("selectedMeteor");
		}
	}

	void whichSelected(){
		if (selectedMeteor == meteor1) {
			asteroidSelectedBool = true;
			basketballSelectedBool = false;
			birdSelectedBool = false;
			spaceShipSelectedBool = false;
		} else if (selectedMeteor == meteor2) {
			asteroidSelectedBool = false;
			basketballSelectedBool = true;
			birdSelectedBool = false;
			spaceShipSelectedBool = false;
		} else if (selectedMeteor == meteor3) {
			asteroidSelectedBool = false;
			basketballSelectedBool = false;
			birdSelectedBool = true;
			spaceShipSelectedBool = false;
		} else if (selectedMeteor == meteor4) {
			asteroidSelectedBool = false;
			basketballSelectedBool = false;
			birdSelectedBool = false;
			spaceShipSelectedBool = true;
		}


	}

}
