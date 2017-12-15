using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proibido : MonoBehaviour {
	public Animator container;
	public Animator camera;
	public Camera camJogo;
	public Camera camCena;
	public Renderer contrend;

	

	// Use this for initialization
	void Start () {
		container.enabled=false;
		camera.enabled=false;
		contrend.enabled=false;
		camCena.enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter( Collider other){
		if(other.tag=="Proibido"){
			contrend.enabled=true;
			container.enabled=true;	
			camera.enabled=true;
			camJogo.enabled=false;
			camCena.enabled=true;
			GetComponent<Rigidbody>().isKinematic=false;
		}
	}

	void OnCollisionEnter( Collision c){
		if(c.gameObject.tag=="Container")
			StartCoroutine(Fim());
	}

	IEnumerator Fim(){
		yield return new WaitForSeconds(2);
			Application.LoadLevel ("Cena0");		
	}

}
