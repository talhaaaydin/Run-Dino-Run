using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class bossScript : MonoBehaviour {
	string arkaPlan, arkaPlan1, arkaPlan2, arkaPlan3, arkaPlan4;

	public Button upButton, downButton;
	public Image upButtonImage, downButtonImage;

	public Color ap1kameraArkaPlanRenk, ap1upButtonImageRenk, ap1downButtonImageRenk;
	public Sprite ap1upButtonSprite, ap1downButtonSprite;

	public Color ap2kameraArkaPlanRenk, ap2upButtonImageRenk, ap2downButtonImageRenk;
	public Sprite ap2upButtonSprite, ap2downButtonSprite;

	public Color ap3kameraArkaPlanRenk, ap3upButtonImageRenk, ap3downButtonImageRenk;
	public Sprite ap3upButtonSprite, ap3downButtonSprite;

	public Color ap4kameraArkaPlanRenk, ap4upButtonImageRenk, ap4downButtonImageRenk;
	public Sprite ap4upButtonSprite, ap4downButtonSprite;

	public GameObject backgroundImages1, backgroundImages2, backgroundImages3, backgroundImages4;
	// Use this for initialization
	void Start () {
		arkaPlan1 = PlayerPrefs.GetString ("arkaPlan1Key");
		arkaPlan2 = PlayerPrefs.GetString ("arkaPlan2Key");
		arkaPlan3 = PlayerPrefs.GetString ("arkaPlan3Key");
		arkaPlan4 = PlayerPrefs.GetString ("arkaPlan4Key");
		Time.timeScale = 1;
		arkaPlan = PlayerPrefs.GetString ("arkaPlan", "0");
		if (arkaPlan == "0") {
			arkaPlan = arkaPlan1;
			PlayerPrefs.SetString ("arkaPlan", arkaPlan1);
		}

		if (arkaPlan == arkaPlan1) {
			Camera.main.backgroundColor = ap1kameraArkaPlanRenk;
			upButton.gameObject.GetComponent<Image> ().sprite = ap1upButtonSprite;
			downButton.gameObject.GetComponent<Image> ().sprite = ap1downButtonSprite;
			upButtonImage.color = ap1upButtonImageRenk;
			downButtonImage.color = ap1downButtonImageRenk;
			Instantiate (backgroundImages1);
		}else if (arkaPlan == arkaPlan2) {
			Camera.main.backgroundColor = ap2kameraArkaPlanRenk;
			upButton.gameObject.GetComponent<Image> ().sprite = ap2upButtonSprite;
			downButton.gameObject.GetComponent<Image> ().sprite = ap2downButtonSprite;
			upButtonImage.color = ap2upButtonImageRenk;
			downButtonImage.color = ap2downButtonImageRenk;
			Instantiate (backgroundImages2);
		}else if (arkaPlan == arkaPlan3) {
			Camera.main.backgroundColor = ap3kameraArkaPlanRenk;
			upButton.gameObject.GetComponent<Image> ().sprite = ap3upButtonSprite;
			downButton.gameObject.GetComponent<Image> ().sprite = ap3downButtonSprite;
			upButtonImage.color = ap3upButtonImageRenk;
			downButtonImage.color = ap3downButtonImageRenk;
			Instantiate (backgroundImages3);
		}else if (arkaPlan == arkaPlan4) {
			Camera.main.backgroundColor = ap4kameraArkaPlanRenk;
			upButton.gameObject.GetComponent<Image> ().sprite = ap4upButtonSprite;
			downButton.gameObject.GetComponent<Image> ().sprite = ap4downButtonSprite;
			upButtonImage.color = ap4upButtonImageRenk;
			downButtonImage.color = ap4downButtonImageRenk;
			Instantiate (backgroundImages4);
		}
	}

}
