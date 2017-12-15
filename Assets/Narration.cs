using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narration : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other){
		if(other.tag=="Carro2")
			FindObjectOfType<AudioManager>().Play("Carro2");
		if(other.tag=="Farol1")
			FindObjectOfType<AudioManager>().Play("Farol1");
		if(other.tag=="NarProi")
			FindObjectOfType<AudioManager>().Play("ChegandoVaga");
		if(other.tag=="Passou1")
			FindObjectOfType<AudioManager>().Play("Passou1");	
		if(other.tag=="Passou2")
			FindObjectOfType<AudioManager>().Play("Passou2");	
		if(other.tag=="Jeremias")
			FindObjectOfType<AudioManager>().Play("Jeremias");		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
