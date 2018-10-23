using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeEffect : MonoBehaviour {

	public Animator camAnim;

	public void CameraShake(){
		camAnim.SetTrigger ("shake");
	}
}
