using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControleInterface : MonoBehaviour {

    public Slider SliderVidaJogador;
    public GameObject PainelGameOver;
    private ControleJogador scriptControleJogador;
    private Status dadosInterface;
    public Text TextoTempoVivo;
    private int zumbisMortos = 0;
    public Text NumeroZumbis;

    void Start () {
        dadosInterface = GetComponent<Status>();
        scriptControleJogador = GameObject.FindWithTag("Player").GetComponent<ControleJogador>();
        SliderVidaJogador.maxValue = scriptControleJogador.DadosJogador.Vida;
        SliderVidaJogador.value = scriptControleJogador.DadosJogador.Vida;
        Time.timeScale = 1;
    }
	
    public void AtualizarVidaJogador() {
        SliderVidaJogador.value = scriptControleJogador.DadosJogador.Vida;
    }

    public void AtualizarZumbisMortos() {
        zumbisMortos++;
        NumeroZumbis.text = string.Format(" x {0}", zumbisMortos);
    }

    public void GameOver() {
        PainelGameOver.SetActive(true);
        Time.timeScale = 0;
        int min = (int)Time.timeSinceLevelLoad / 60;
        int seg = (int)Time.timeSinceLevelLoad % 60;
        int zumbisMortos = scriptControleJogador.zumbisMortos;
        TextoTempoVivo.text = "Tempo vivo: " + min +  "min e " + seg + "s\n\nZumbis mortos: " + zumbisMortos;
    }

    public void Reiniciar() {
        SceneManager.LoadScene("Game");
    }
}
