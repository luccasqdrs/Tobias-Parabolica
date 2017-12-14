using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour {
	private bool press;
	public Animator ani;
	private Vector3 start;
	void Start(){
		ani.enabled=false;
		
	}
	void OnTriggerStay( Collider other){
		if(other.tag=="VirarEsq" && Input.GetKey(KeyCode.LeftArrow))
			press=true;
	}

	void OnTriggerExit( Collider other){
		if(press)
			ani.enabled=true;
	}
}
