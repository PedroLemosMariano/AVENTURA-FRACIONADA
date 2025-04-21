using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class QuestoesQuiz : MonoBehaviour
{
    [Header("------> Configurações do Tema e Quantidade <------")]
    public int idTema;
    public int numQuestoes;

    [Header("------> Referências de UI <------")]
    public Image imagemAuxilio;
    public TextMeshProUGUI textoPergunta;
    public TextMeshProUGUI textoRespostaA;
    public GameObject botaoRespostaA;
    public TextMeshProUGUI textoRespostaB;
    public GameObject botaoRespostaB;
    public TextMeshProUGUI textoRespostaC;
    public GameObject botaoRespostaC;
    public TextMeshProUGUI textoRespostaD;
    public GameObject botaoRespostaD;
    public TextMeshProUGUI textoRespostaAcertos;

    [Header("------> Paineis e Navegação <------")]
    public string ProxCena;
    public bool QuizSimples;
    public GameObject painelQuiz;
    public GameObject painelAcertos;

    [Header("------> Estrelas de Pontuação <------")]
    public Image estrelaEscura1;
    public Image estrelaEscura2;
    public Image estrelaClara1;
    public Image estrelaClara2;

    [Header("------> Banco de Dados das Questões <------")]
    public bool[] questoesComImagem;
    public Sprite[] representaVisual;
    public string[] perguntas;
    public string[] alternativaA;
    public string[] alternativaB;
    public string[] alternativaC;
    public string[] alternativaD;
    public string[] respostaCorreta; // Deve conter "A", "B", "C" ou "D"

    private int idPergunta;
    private float acertos;
    private float totalQuestoes;

    void Start()
    {
        idPergunta = 0;
        totalQuestoes = perguntas.Length;
        AtualizarPergunta();
    }

    public void Responder(string alternativa)
    {
        if (respostaCorreta[idPergunta] == alternativa)
        {
            acertos++;
        }

        DestacarBotaoCorreto();
        Invoke(nameof(ProximaPergunta), 1f);
    }

    void ProximaPergunta()
    {
        idPergunta++;
        if (idPergunta < totalQuestoes)
        {
            AtualizarPergunta();
        }
        else
        {
            FinalizarQuiz();
        }
    }

    void FinalizarQuiz()
    {
        Debug.Log("Quiz finalizado!");

        painelQuiz.SetActive(false);
        painelAcertos.SetActive(true);

        PlayerPrefs.SetFloat("Acertos", acertos);
        textoRespostaAcertos.text = $"Você acertou {acertos} de {totalQuestoes} perguntas!";


        if (QuizSimples)
        {
            AtualizarEstrelas();
            StartCoroutine(FecharAcertos(2f));
        }
        else
        {
            AtualizarEstrelas();
            StartCoroutine(CarregarCenaAposDelay(2f));
        }
            
    }

    IEnumerator CarregarCenaAposDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(ProxCena);
    }

    IEnumerator FecharAcertos(float delay)
    {
        yield return new WaitForSeconds(delay);
        painelAcertos.SetActive(false);
        PauseController.SetPause(false);
    }

    void AtualizarEstrelas()
    {
        float percentual = acertos / totalQuestoes;

        estrelaClara1.gameObject.SetActive(percentual >= 0.5f);
        estrelaEscura1.gameObject.SetActive(percentual < 0.5f);
        estrelaClara2.gameObject.SetActive(percentual >= 0.9f);
        estrelaEscura2.gameObject.SetActive(percentual < 0.9f);
    }

    void AtualizarPergunta()
    {
        bool temImagem = imagemAuxilio != null && questoesComImagem.Length > idPergunta && questoesComImagem[idPergunta];
        if (temImagem && representaVisual.Length > idPergunta && representaVisual[idPergunta] != null)
        {
            imagemAuxilio.sprite = representaVisual[idPergunta];
            imagemAuxilio.gameObject.SetActive(true);
        }
        else if (imagemAuxilio != null)
        {
            imagemAuxilio.gameObject.SetActive(false);
        }

        textoPergunta.text = perguntas[idPergunta];
        textoRespostaA.text = alternativaA[idPergunta];
        textoRespostaB.text = alternativaB[idPergunta];
        textoRespostaC.text = alternativaC[idPergunta];
        textoRespostaD.text = alternativaD[idPergunta];

        ResetarCoresDosBotoes();
    }

    void DestacarBotaoCorreto()
    {
        switch (respostaCorreta[idPergunta])
        {
            case "A": botaoRespostaA.GetComponent<Image>().color = Color.green; break;
            case "B": botaoRespostaB.GetComponent<Image>().color = Color.green; break;
            case "C": botaoRespostaC.GetComponent<Image>().color = Color.green; break;
            case "D": botaoRespostaD.GetComponent<Image>().color = Color.green; break;
        }
    }

    void ResetarCoresDosBotoes()
    {
        Color branco = Color.white;
        botaoRespostaA.GetComponent<Image>().color = branco;
        botaoRespostaB.GetComponent<Image>().color = branco;
        botaoRespostaC.GetComponent<Image>().color = branco;
        botaoRespostaD.GetComponent<Image>().color = branco;
    }
}
