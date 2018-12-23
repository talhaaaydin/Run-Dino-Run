using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marketScript : MonoBehaviour {

	public GameObject BackgroundPanel, MeteorPanel;
	public int arkaPlan2price = 300, arkaPlan3price = 750, arkaPlan4Price = 1450;
	public int meteor2price = 60, meteor3price = 100, meteor4price = 140;

	void Start(){
		backgroundPriceSettings ();
		meteorPriceSettings ();
	}

	public void backgroundPriceSettings(){
		PlayerPrefs.SetInt ("arkaPlan2Price", arkaPlan2price);
		PlayerPrefs.SetInt ("arkaPlan3Price", arkaPlan3price);
		PlayerPrefs.SetInt ("arkaPlan4Price", arkaPlan4Price);
	}

	public void meteorPriceSettings(){
		PlayerPrefs.SetInt ("meteor2Price", meteor2price);
		PlayerPrefs.SetInt ("meteor3Price", meteor3price);
		PlayerPrefs.SetInt ("meteor4Price", meteor4price);
	}

	public void BackgroundPanelButton(){
		BackgroundPanel.SetActive (true);
		MeteorPanel.SetActive (false);
	}

	public void MeteorPanelButton(){
		BackgroundPanel.SetActive (false);
		MeteorPanel.SetActive (true);
	}
}
