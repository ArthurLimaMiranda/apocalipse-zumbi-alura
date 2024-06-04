using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCamera : MonoBehaviour {

    public GameObject Jogador;
    Vector3 camdir;

	// Use this for initialization
	void Start () {

        camdir = transform.position - Jogador.transform.position;

	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Jogador.transform.position + camdir;

	}
}
 