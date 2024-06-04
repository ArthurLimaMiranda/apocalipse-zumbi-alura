using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleMovimentoJogador : ControleMovimentoObjeto {

    public void RotacaoJogador(LayerMask MascaraChao) {

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100, MascaraChao)) {
            Vector3 mirapos = impacto.point - transform.position;

            mirapos.y = transform.position.y;

            Rotacionar(mirapos);
        }
    }
}
