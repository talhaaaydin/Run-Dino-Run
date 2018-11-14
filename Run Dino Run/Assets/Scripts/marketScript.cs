using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marketScript : MonoBehaviour {

	public GameObject BackgroundPanel, MeteorPanel;
	public int arkaPlan2price = 600, arkaPlan3price = 1500;
	public int meteor2price = 100, meteor3price = 200;

	void Start(){
		backgroundPriceSettings ();
		meteorPriceSettings ();
	}

	public void backgroundPriceSettings(){
		PlayerPrefs.SetInt ("arkaPlan2Price", arkaPlan2price);
		PlayerPrefs.SetInt ("arkaPlan3Price", arkaPlan3price);
	}

	public void meteorPriceSettings(){
		PlayerPrefs.SetInt ("meteor2Price", meteor2price);
		PlayerPrefs.SetInt ("meteor3Price", meteor3price);
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
