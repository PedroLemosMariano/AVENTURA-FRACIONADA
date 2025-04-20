using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestoesQuiz : MonoBehaviour
{
    public int idTema;

    public int numQuestoes;
    public bool[] questoesComImagem;
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

    public string ProxCena;
    public bool QuizSimples;
    public GameObject QuizzPannel;

    public Sprite[] representaVisual;
    public string[] perguntas;
    public string[] alternativaA;
    public string[] alternativaB;
    public string[] alternativaC;
    public string[] alternativaD;
    public string[] respostaCorreta; // Deve conter "A", "B", "C", "D"

    private int idPergunta;
    private float acertos;
    private float questoes;

    void Start()
    {
        idPergunta = 0;
        questoes = perguntas.Length;
        AtualizarPergunta();
    }

    public void Resposta(string Alternativa)
    {
        if (respostaCorreta[idPergunta] == Alternativa)
        {
            acertos++;
        }

        DestacarBotaoCorreto();
        Invoke(nameof(ProximaPergunta), 1f);
    }

    void ProximaPergunta()
    {
        idPergunta++;
        if (idPergunta < questoes)
        {
            AtualizarPergunta();
        }
        else
        {
            Debug.Log("Quiz terminado! Acertos: " + acertos + "/" + questoes);

            if (QuizSimples)
            {
                QuizzPannel.SetActive(false);
                PauseController.SetPause(false);
            }
            else
            {
                PlayerPrefs.SetFloat("Acertos", acertos);
                PlayerPrefs.SetFloat("TotalQuestoes", questoes);
                SceneManager.LoadScene(ProxCena);
            }
        }
    }

    void AtualizarPergunta()
    {
        if (imagemAuxilio != null && questoesComImagem.Length > idPergunta && questoesComImagem[idPergunta])
        {
            if (representaVisual.Length > idPergunta && representaVisual[idPergunta] != null)
            {
                imagemAuxilio.sprite = representaVisual[idPergunta];
                imagemAuxilio.gameObject.SetActive(true);
            }
            else
            {
                imagemAuxilio.gameObject.SetActive(false);
            }
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
            case "A":
                botaoRespostaA.GetComponent<Image>().color = Color.green;
                break;
            case "B":
                botaoRespostaB.GetComponent<Image>().color = Color.green;
                break;
            case "C":
                botaoRespostaC.GetComponent<Image>().color = Color.green;
                break;
            case "D":
                botaoRespostaD.GetComponent<Image>().color = Color.green;
                break;
        }
    }

    void ResetarCoresDosBotoes()
    {
        botaoRespostaA.GetComponent<Image>().color = Color.white;
        botaoRespostaB.GetComponent<Image>().color = Color.white;
        botaoRespostaC.GetComponent<Image>().color = Color.white;
        botaoRespostaD.GetComponent<Image>().color = Color.white;
    }
}
