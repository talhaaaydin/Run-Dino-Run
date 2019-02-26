using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openUrl : MonoBehaviour {

	public string url = "www.noiseforfun.com";
	public void OpenUrl(){
		Application.OpenURL (url);
	}
}
