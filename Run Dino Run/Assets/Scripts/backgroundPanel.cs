using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundPanel : MonoBehaviour {
	public Text arkaPlan2priceText, arkaPlan3priceText;
	public Button forestBuyBtn, cityBuyBtn;
	public Sprite forestBuyBtnDefault, cityBuyBtnDefault, forestPurchasedSpr, cityPurschasedSpr, canNotBe;
	bool forestPurchasedBool, cityPurchasedBool;
	GameObject bossMainMenu;
	string arkaPlan2, arkaPlan3;
	int arkaPlan2price, arkaPlan3price;

	// Use this for initialization
	void Start () {
		bossMainMenu = GameObject.FindGameObjectWithTag ("_BossMainMenu");
		arkaPlan2 = bossMainMenu.GetComponent<bossOftheMainMenu> ().arkaPlan2;
		arkaPlan3 = bossMainMenu.GetComponent<bossOftheMainMenu> ().arkaPlan3;
	}

	void Update(){
		isPurchased ();
		ButtonSettings ();
		TextSettings ();
		isThereMoneyEnough ();
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
		if (forestPurchasedBool) {
			Destroy (forestBuyBtn.GetComponent<Button> ());
			forestBuyBtn.GetComponent<Image> ().sprite = forestPurchasedSpr;
		}

		if (cityPurchasedBool) {
			Destroy (cityBuyBtn.GetComponent<Button> ());
			cityBuyBtn.GetComponent<Image> ().sprite = cityPurschasedSpr;
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
		if (money >= arkaPlan2price) {
			forestBuyBtn.interactable = true;
			//forestBuyBtn.GetComponent<Image> ().sprite = forestBuyBtnDefault;
		} else {
			forestBuyBtn.interactable = false;
		}

		if(money >= arkaPlan3price){
			cityBuyBtn.interactable = true;
			//cityBuyBtn.GetComponent<Image> ().sprite = forestBuyBtnDefault;
		} else {
			cityBuyBtn.interactable = false;
		}
	}

	public void BuyButton(string arkaPlan){
		
	}
}
