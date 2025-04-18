using System.Collections;
using UnityEngine;

public class QuizOPen : MonoBehaviour
{
    [SerializeField] GameObject abrirLogo;
    [SerializeField] GameObject abrirQuiz;

    IEnumerator RotinaDeControle()
    {
        yield return new WaitForSeconds(3f);
        abrirLogo.SetActive(false);
        abrirQuiz.SetActive(true);
    }

    void Start()
    {
        StartCoroutine(RotinaDeControle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
