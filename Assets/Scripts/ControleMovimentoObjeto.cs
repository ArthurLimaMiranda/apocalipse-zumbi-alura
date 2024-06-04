using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMovimentoObjeto : MonoBehaviour {

    private Rigidbody rigidbodyObjeto;

    void Awake() {

        rigidbodyObjeto = GetComponent<Rigidbody>();
        
    }

    public void Movimentar(Vector3 dir, float speed) {

        rigidbodyObjeto.MovePosition(rigidbodyObjeto.position + (dir.normalized * speed * Time.deltaTime));

    }

    public void Rotacionar(Vector3 dir) {

        Quaternion girando = Quaternion.LookRotation(dir);

        rigidbodyObjeto.MoveRotation(girando);

    }

}