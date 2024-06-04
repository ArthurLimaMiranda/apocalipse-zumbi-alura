using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleArma : MonoBehaviour {

    public GameObject Bala;
    public GameObject Cano;
    public AudioClip SomDeTiro;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")){
            Instantiate(Bala, Cano.transform.position, Cano.transform.rotation);
            ControleAudio.instancia.PlayOneShot(SomDeTiro);
        }
	}
}
