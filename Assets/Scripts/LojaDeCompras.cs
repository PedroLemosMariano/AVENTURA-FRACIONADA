using UnityEngine;
using TMPro;
using System.Collections;


public class LojaDeCompras : MonoBehaviour
{
    [SerializeField] private GameObject AvisoDeTaDuro;

    public void Compra(float valor)
    {
        if (PlayerPrefs.GetFloat("moeda") >= valor)
        {
            PlayerPrefs.SetFloat("moeda", PlayerPrefs.GetFloat("moeda") - valor);
            Debug.Log("Compra realizada com sucesso!");
        }
        else
        {
            StartCoroutine(Tempo());
            Debug.Log("Moedas insuficientes para a compra.");
        }
    }
    IEnumerator Tempo()
    {
        AvisoDeTaDuro.SetActive(true);
        yield return new WaitForSeconds(2f);
        AvisoDeTaDuro.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
