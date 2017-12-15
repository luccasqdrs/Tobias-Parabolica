using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tobiascontroller : MonoBehaviour {

	static Animator anim;
	public float speed;
	public float rotationspeed;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}


	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationspeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (translation != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }
}
