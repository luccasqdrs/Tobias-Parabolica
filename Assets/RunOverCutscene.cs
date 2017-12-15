using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunOverCutscene : MonoBehaviour {


    public Camera cam1, cam2;
   
    public Animator anim1, anim2;

    public GameObject player;

    public GameObject bus;

    private void Start()
    {
        anim1.enabled = false;
        anim2.enabled = false;
        bus.SetActive(false);
        
    }




    void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("A"))
        {
            
            cam1.enabled = true;

            anim1.enabled = true;
            anim2.enabled = true;
            bus.SetActive(true);
        }

        if (other.CompareTag("B"))
        {
            foreach (var cam in Camera.allCameras)
            {
                cam.enabled = false;
            }
            cam2.enabled = true;

            Vector3 pastel = new Vector3(10, 1, 10);

            player.transform.localScale = pastel;
            StartCoroutine(Fim());
            FindObjectOfType<AudioManager1>().Play("Onibus");
        }

        if (other.CompareTag("C"))
        {
            FindObjectOfType<AudioManager1>().Play("Faixa1");
        }

        if (other.CompareTag("D"))
        {
            FindObjectOfType<AudioManager1>().Play("Faixa2");
        }

        if(other.CompareTag("End"))
        {
            Application.LoadLevel("Cena1");
        }

    }

    IEnumerator Fim()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel("Cena0");
    }
}
