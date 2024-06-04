using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleZumbi : MonoBehaviour, IMorrivel {

    public GameObject Jogador;

    public float TempoEntreDir = 4;
    private float contaVagar;
    private float distVagar = 15;

    private float contaTempoSom = 0;
    public float TempoSom = 6;
    
    public AudioClip SomDeMorte;
    public AudioClip SomDeZumbi;
    private ControleMovimentoObjeto movObjeto;
    private ControleAnimacao animaObjeto;
    public Status dadosZumbi;
    private float distanciaAway = 15;
    private float distanciaAtaque = 2.5f;
    private Vector3 randomPosicao;
    private Vector3 dir;
    private float chanceKit = 0.1f;
    public GameObject KitMedico;
    private ControleInterface interfaceController;


    // Use this for initialization
    void Start() {
        dadosZumbi = GetComponent<Status>();
        dadosZumbi.Velocidade = Random.Range(1, 6);
        dadosZumbi.VidaInicial = Random.Range(55, 101);
        dadosZumbi.Vida = dadosZumbi.VidaInicial;
        RandomSkin();
        Jogador = GameObject.FindWithTag("Player"); 
        movObjeto = GetComponent<ControleMovimentoObjeto>();
        animaObjeto = GetComponent<ControleAnimacao>();
        interfaceController = GameObject.FindObjectOfType(typeof(ControleInterface)) as ControleInterface;
    }

    void FixedUpdate() {
        
        float dist = Vector3.Distance(transform.position, Jogador.transform.position);
        movObjeto.Rotacionar(dir);

        animaObjeto.Mover(dir.magnitude);
                
        if (dist > distanciaAway) {
            Vagabond();
        }

        else if (dist > distanciaAtaque) {

            contaTempoSom += Time.deltaTime;  
            if (contaTempoSom >= TempoSom) {
                ControleAudio.instancia.PlayOneShot(SomDeZumbi, (float)0.5);
                contaTempoSom = 0;
            }

            dir = Jogador.transform.position - transform.position;
            animaObjeto.Atacar(false);
            movObjeto.Movimentar(dir, dadosZumbi.Velocidade);
        }

        else {
            dir = Jogador.transform.position - transform.position;
            animaObjeto.Atacar(true);
        }
    }

    void AtacaJogador() {
        dadosZumbi.Dano = Random.Range(15, 26);
        Jogador.GetComponent<ControleJogador>().TomarDano(dadosZumbi.Dano);
    }

    void RandomSkin() {
        int skin = Random.Range(1, 28);
        transform.GetChild(skin).gameObject.SetActive(true);
    }

    void Vagabond() {

        contaVagar -= Time.deltaTime;

        if(contaVagar <= 0) {
            randomPosicao = AleatorizarPosicao();
            contaVagar = TempoEntreDir;
        }

        bool pertin = Vector3.Distance(transform.position, randomPosicao) <= 0.05;

        if (!pertin) {
            dir = randomPosicao - transform.position;
            movObjeto.Movimentar(dir, dadosZumbi.Velocidade);
        }

    }

    Vector3 AleatorizarPosicao() {

        Vector3 posicao = Random.insideUnitSphere * distVagar;
        posicao += transform.position;
        posicao.y = transform.position.y;

        return posicao;

    }

    public void TomarDano(int dano) {

    dadosZumbi.Vida -= dano;
        StartCoroutine(animaObjeto.Piscalerta());
        if (dadosZumbi.Vida <= 0) {
            Morrer();
        }
    }

    public void Morrer() {
        Destroy(gameObject);
        ControleAudio.instancia.PlayOneShot(SomDeMorte);
        GeraKit(chanceKit);
        interfaceController.AtualizarZumbisMortos();
    }

    void GeraKit(float chance) {
        if(Random.value <= chance) {
            Instantiate(KitMedico, transform.position, Quaternion.identity);
        }
    }

}
 