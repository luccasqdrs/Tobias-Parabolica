using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour {
	public Material desligado;
	public Material verde;
	public Material vermelho;
	public Renderer sign;
	private Material[] mats;
	public Animator truck;
	public Animator camera;
	public Rigidbody rb;
	private bool morte=true;
	// Use this for initialization
	void Start(){
		mats= sign.materials;
		Debug.Log(sign.materials);
		for(int i=2;i<4;i++)
			mats[i]=desligado;
		sign.materials=mats;
		truck.enabled=false;
		camera.enabled=false;

		rb = GetComponent<Rigidbody>();
	}
	void OnTriggerEnter( Collider other){
		if(other.tag=="Signal"){
			mats[4]=desligado;
			mats[3]=vermelho;
		}
		sign.materials=mats;
		StartCoroutine(Espera());
		Debug.Log("After espera");
	}

	void OnTriggerExit( Collider other){
		if (morte)
		{
			truck.enabled=true;
			camera.enabled=true;
			rb.isKinematic = false;
	
		}
			}

	void OnCollisionEnter( Collision c){
		Application.LoadLevel ("Cena1");
	}

	IEnumerator Espera(){
		yield return new WaitForSeconds(10);
		Debug.Log("Esperou");
		mats[4]= verde;
		mats[3]= desligado;
		sign.materials=mats;
		morte= false;
	}
}
