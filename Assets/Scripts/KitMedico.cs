using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitMedico : MonoBehaviour {

    private int regen = 15;
    private int autoKillTempo = 5;
    private ControleAnimacao animaObjeto;

    private void Start() {
        animaObjeto = GetComponent<ControleAnimacao>();
        Destroy(gameObject, autoKillTempo);
        
    }


    private void OnTriggerEnter(Collider colidendo) {

        if (colidendo.tag == "Player") {
            if (colidendo.GetComponent<ControleJogador>().DadosJogador.Vida <100) {
                Destroy(gameObject);
                colidendo.GetComponent<ControleJogador>().CuraVida(regen);
            }
         
        }
        
    }

}
