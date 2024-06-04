using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour {

    public GameObject Zumbi;

    private GameObject jogador;

    private float contaTempo = 0;

    public float TempoGerador = 2;

    public LayerMask LayerZumbi;

    private float genArea = 3;

    private float distMinGer = 15;

    private void Start() {
        jogador = GameObject.FindWithTag("Player");
    }

    void Update () {

        contaTempo += Time.deltaTime;
      
        if(contaTempo >= TempoGerador && Vector3.Distance(transform.position, jogador.transform.position) >= distMinGer) {
            StartCoroutine(GeraZumbi());
            contaTempo = 0; 
        } 
	}

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, genArea);
    }

    IEnumerator GeraZumbi() {
        Vector3 posicaoGerada = AleatorizarPosicao();
        Collider[] colisores = Physics.OverlapSphere(posicaoGerada, 1, LayerZumbi);
        while(colisores.Length > 0) {
            posicaoGerada = AleatorizarPosicao();
            colisores = Physics.OverlapSphere(posicaoGerada, 1, LayerZumbi);
            yield return null;
        }
        Instantiate(Zumbi, posicaoGerada, transform.rotation);
        
    }

    Vector3 AleatorizarPosicao() {

        Vector3 posicao = Random.insideUnitSphere * genArea;
        posicao += transform.position;
        posicao.y = transform.position.y;

        return posicao;

    }
}
