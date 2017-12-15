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
	private bool wait;
	private int cont;
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
		wait=true;
		if(other.tag=="Signal"){
			mats[4]=desligado;
			mats[3]=vermelho;
		sign.materials=mats;
		FindObjectOfType<AudioManager>().Play("Farol"+2);
		StartCoroutine(Espera());
		Debug.Log("After espera");
		}
		
	}

	void OnTriggerExit( Collider other){
		wait=false;
		if(other.tag=="Signal"){
			if (morte)
			{
				truck.enabled=true;
				camera.enabled=true;
				rb.isKinematic = false;
		
			}
			FindObjectOfType<AudioManager>().Play("AbriuFarol2");
		}
			}

	void OnCollisionEnter( Collision c){
		if(c.gameObject.tag=="Truck")
			Application.LoadLevel ("Cena0");
	}

	IEnumerator Espera(){
		for(int i=3;i<9;i++){
			yield return new WaitForSeconds(8);
			FindObjectOfType<AudioManager>().Play("Farol"+i);	
		}
		yield return new WaitForSeconds(5);
		abreFarol();
	}

	void abreFarol(){
		Debug.Log("Esperou");
		mats[4]= verde;
		mats[3]= desligado;
		sign.materials=mats;
		morte= false;
		FindObjectOfType<AudioManager>().Play("AbriuFarol1");
	}
}
