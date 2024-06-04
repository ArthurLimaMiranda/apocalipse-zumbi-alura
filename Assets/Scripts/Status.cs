using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    public float Velocidade = 7;
    public int VidaInicial = 100;
    public int Dano;
    [HideInInspector]
    public int Vida;


    void Awake() {

        Vida = VidaInicial;

    }

}