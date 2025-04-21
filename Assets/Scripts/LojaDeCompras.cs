using UnityEngine;
using TMPro;
using System.Collections;
using static ResetarUpdates;
using static PowerupsAtivos;

public class LojaDeCompras : MonoBehaviour
{
    [SerializeField] private GameObject AvisoDeTaDuro;

    // Função genérica de compra
    public void CompraMoedasX2(int preco)
    {
        float moedas = PlayerPrefs.GetFloat("moeda", 0f);

        if (moedas >= preco)
        {
            moedas -= preco;
            PlayerPrefs.SetFloat("moeda", moedas);

            PlayerPrefs.SetInt("moedaX2", 1);
            PowerUpsAtivos.moedaX2 = true;

            Debug.Log("Compra realizada: Moedas x2 ativado! Restaram: " + moedas);
        }
        else
        {
            StartCoroutine(MostrarAviso());
            Debug.Log("Moedas insuficientes. Você tem: " + moedas);
        }
    }

    public void CompraAgilidade(int preco)
    {
        float moedas = PlayerPrefs.GetFloat("moeda", 0f);

        if (moedas >= preco)
        {
            moedas -= preco;
            PlayerPrefs.SetFloat("moeda", moedas);

            PowerUpsAtivos.agilidade = true;

            FindFirstObjectByType<PlayerMovement>().AtivarAgilidade(); // ativa no momento

            Debug.Log("Compra realizada: Agilidade ativada! Restaram: " + moedas);
        }
        else
        {
            StartCoroutine(MostrarAviso());
            Debug.Log("Moedas insuficientes para comprar agilidade. Você tem: " + moedas);
        }
    }

    IEnumerator MostrarAviso()
    {
        if (AvisoDeTaDuro != null)
        {
            AvisoDeTaDuro.SetActive(true);
            yield return new WaitForSeconds(2f);
            AvisoDeTaDuro.SetActive(false);
        }
    }
}