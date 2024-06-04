using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAudio : MonoBehaviour {

    private AudioSource audios;

    public static AudioSource instancia;

    void Awake() {
        audios = GetComponent<AudioSource>();
        instancia = audios;
    }

}
 