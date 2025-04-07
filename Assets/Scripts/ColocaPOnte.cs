using UnityEngine;
using TMPro;
using System.Collections;

public class ColocaPOnte : MonoBehaviour
{
    public int contadorPonte;
    public static ColocaPOnte Instance;
    public GameObject Tijolo;
    public GameObject Pannel;
    public GameObject PannelFracao;
    public TextMeshProUGUI TextoFracao;
    public int numeroAtual;
    public float valorReferenciaX;
    public float valorReferenciaY;

    public void Coloca()
    {
        switch (contadorPonte)
        {
            case 0:
                Ponte(0, 0);
                contadorPonte++;
                StartCoroutine(Tempo());
                break;
            case 1:
                Ponte(-1, 0);
                contadorPonte++;
                StartCoroutine(Tempo());
                break;
            case 2:
                Ponte(-1, 1);
                contadorPonte++;
                StartCoroutine(Tempo());
                break;
            case 3:
                Ponte(-1, 2);
                contadorPonte++;
                StartCoroutine(Tempo());
                break;
            case 4:
                Ponte(0, 1);
                contadorPonte++;
                StartCoroutine(Tempo());
                break;
            case 5:
                Ponte(0, 2);
                contadorPonte++;
                StartCoroutine(Tempo());
                break;
            case 6:
                Ponte(1, 1);
                contadorPonte++;
                StartCoroutine(Tempo());
                break;
            case 7:
                Ponte(1, 2);
                contadorPonte++;
                StartCoroutine(Tempo());
                Destroy(gameObject);
                break;
            default:
                Destroy(gameObject);
                Debug.Log("Limite de ponte atingido");
                break;
        }
    }

    public void ColocaTudo()
    {
        Ponte(0, 0);
        Ponte(-1, 0);
        Ponte(-1, 1);
        Ponte(-1, 2);
        Ponte(0, 1);
        Ponte(0, 2);
        Ponte(1, 1);
        Ponte(1, 2);
        Ponte(2, 0);
        Ponte(1, 0);
        Ponte(3, 0);
        Ponte(2, 1);

        StartCoroutine(PainelApareceComTempoDepoisDestroi());

    }
    IEnumerator PainelApareceComTempoDepoisDestroi()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        PannelFracao.SetActive(true);
        TextoFracao.text = (contadorPonte + numeroAtual).ToString();
        yield return new WaitForSeconds(2f);
        PannelFracao.SetActive(false);
    }

    IEnumerator Tempo()
    {
        PannelFracao.SetActive(true);
        TextoFracao.text = (contadorPonte + numeroAtual).ToString();
        yield return new WaitForSeconds(2f);
        PannelFracao.SetActive(false);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Ponte(float a, float b)
    {
        Vector3 position = new Vector3(valorReferenciaX + a, valorReferenciaY + b, 0);
        Instantiate(Tijolo, position, Quaternion.identity);
        Debug.Log("Tijolo spawned at position: " + position);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pannel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pannel.SetActive(false);
        }
    }
}
