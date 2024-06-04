using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogador : MonoBehaviour, IMorrivel, ICuravel {

    public Vector3 dir;
    public ControleInterface scriptControleInterface;
    public AudioClip SomDeDano;
    public LayerMask MascaraChao;
    public Status DadosJogador;
    private ControleMovimentoJogador movJogador;
    private ControleAnimacao animaJogador;
    public int zumbisMortos;

    void Start() {
        movJogador = GetComponent<ControleMovimentoJogador>();
        animaJogador = GetComponent<ControleAnimacao>();
        DadosJogador = GetComponent<Status>();
        zumbisMortos = 0;
    }

    void Update() {

        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");
        dir = new Vector3(eixoX, 0, eixoZ);

        animaJogador.Mover(dir.magnitude);
    }

    void FixedUpdate() {

        movJogador.Movimentar(dir, DadosJogador.Velocidade);

        movJogador.RotacaoJogador(MascaraChao);

    }

    public void TomarDano(int dano) {
        DadosJogador.Vida -= dano;
        scriptControleInterface.AtualizarVidaJogador();
        ControleAudio.instancia.PlayOneShot(SomDeDano);
        StartCoroutine(animaJogador.Piscalerta());
        if (DadosJogador.Vida <= 0) {
            Morrer();
        }
    }

    public void Morrer() {
        scriptControleInterface.GameOver();
    }

    public void CuraVida (int life) {
        DadosJogador.Vida += life;
        if (DadosJogador.Vida > DadosJogador.VidaInicial) {
            DadosJogador.Vida = DadosJogador.VidaInicial;
        }
        scriptControleInterface.AtualizarVidaJogador();
    }
}
