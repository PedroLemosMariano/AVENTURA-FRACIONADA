using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestoesQuiz : MonoBehaviour
{
    public int idTema;

    public int numQuestoes;
    public TextMeshProUGUI textoPergunta;
    public TextMeshProUGUI textoRespostaA;
    public TextMeshProUGUI textoRespostaB;
    public TextMeshProUGUI textoRespostaC;
    public TextMeshProUGUI textoRespostaD;
    //public TextMeshProUGUI dicaComprada;

    public string[] perguntas;
    public string[] alternativaA;
    public string[] alternativaB;
    public string[] alternativaC;
    public string[] alternativaD;
    public string[] respostaCorreta;

    private int idPergunta;

    private float acertos;
    private float questoes;

    public string ProxCena;

    void Start()
    {
        idPergunta = 0;
        questoes = perguntas.Length;

        textoPergunta.text = perguntas[idPergunta];
        textoRespostaA.text = alternativaA[idPergunta];
        textoRespostaB.text = alternativaB[idPergunta];
        textoRespostaC.text = alternativaC[idPergunta];
        textoRespostaD.text = alternativaD[idPergunta];
    }

    public void Resposta(string Alternativa)
    {
        switch (Alternativa)
        {
            case "A":
                if (respostaCorreta[idPergunta] == alternativaA[idPergunta])
                {
                    acertos++;
                }
                break;
            case "B":
                if (respostaCorreta[idPergunta] == alternativaB[idPergunta])
                {
                    acertos++;
                }
                break;
            case "C":
                if (respostaCorreta[idPergunta] == alternativaC[idPergunta])
                {
                    acertos++;
                }
                break;
            case "D":
                if (respostaCorreta[idPergunta] == alternativaD[idPergunta])
                {
                    acertos++;
                }
                break;
        }
        ProximaPergunta();
    }

    void ProximaPergunta()
    {
        idPergunta++;
        if (idPergunta < questoes)
        {
            textoPergunta.text = perguntas[idPergunta];
            textoRespostaA.text = alternativaA[idPergunta];
            textoRespostaB.text = alternativaB[idPergunta];
            textoRespostaC.text = alternativaC[idPergunta];
            textoRespostaD.text = alternativaD[idPergunta];
        }
        else
        {
            SceneManager.LoadScene(ProxCena);
            Debug.Log("Quiz terminado! Acertos: " + acertos + "/" + questoes);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
