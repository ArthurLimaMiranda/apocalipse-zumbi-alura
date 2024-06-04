using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleBala : MonoBehaviour {

    private Rigidbody balaRigidbody;
    private Status dadosBala;
    private ControleJogador dadosMortes;


    void Start() {
        dadosBala = GetComponent<Status>();
        dadosBala.Velocidade = 15;
        balaRigidbody = GetComponent<Rigidbody>();
        dadosBala.Dano = Random.Range(35, 56);
        dadosMortes = GetComponent<ControleJogador>();
    }

    void FixedUpdate() {
        balaRigidbody.MovePosition(balaRigidbody.position + transform.forward * dadosBala.Velocidade * Time.deltaTime);
    }

    void OnTriggerEnter(Collider colidido) {

        if (colidido.gameObject.tag == "Inimigo") {

            colidido.GetComponent<ControleZumbi>().TomarDano(dadosBala.Dano);

        }

        Destroy(gameObject);
    }

}
