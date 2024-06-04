using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAnimacao : MonoBehaviour {

    private Animator animacaoObjeto;

    private void Awake() {

        animacaoObjeto = GetComponent<Animator>();
       
    }

    public void Atacar(bool estado) {

        animacaoObjeto.SetBool("Atacando", estado);

    }

    public void Mover(float valorMov) {

        animacaoObjeto.SetFloat("Movendo", valorMov);

    }

    public IEnumerator Piscalerta() {

        float time = 0.05f;
        float intervalTime = 0.05f;
        //this counts up time until the float set in FlashingTime
        float elapsedTime = 0f;
        //This repeats our coroutine until the FlashingTime is elapsed
        while (elapsedTime < time) {
            //This gets an array with all the renderers in our gameobject's children
            Renderer[] RendererArray = GetComponentsInChildren<Renderer>();
            //this turns off all the Renderers
            foreach (Renderer r in RendererArray)
                r.enabled = false;
            //then add time to elapsedtime
            elapsedTime += Time.deltaTime;
            //then wait for the Timeinterval set
            yield return new WaitForSeconds(intervalTime);
            //then turn them all back on
            foreach (Renderer r in RendererArray)
                r.enabled = true;
            elapsedTime += Time.deltaTime;
            //then wait for another interval of time
            yield return new WaitForSeconds(intervalTime);
        }

    }


}