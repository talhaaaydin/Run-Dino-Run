using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marketScript : MonoBehaviour {

	public GameObject BackgroundPanel, MeteorPanel;
	public int arkaPlan2price = 600, arkaPlan3price = 1500;

	void Start(){
		backgroundPriceSettings ();
	}

	public void backgroundPriceSettings(){
		PlayerPrefs.SetInt ("arkaPlan2Price", arkaPlan2price);
		PlayerPrefs.SetInt ("arkaPlan3Price", arkaPlan3price);
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
