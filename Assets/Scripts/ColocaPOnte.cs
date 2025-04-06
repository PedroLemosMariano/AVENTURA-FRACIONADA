using System.Xml.Linq;
using UnityEngine;

public class ColocaPOnte : MonoBehaviour
{
    public int contadorPonte;
    public static ColocaPOnte Instance;
    public GameObject Tijolo;
    public GameObject Pannel;

    public void Coloca()
    {
        switch (contadorPonte)
        {
            case 0:
                Ponte(0, 0);
                contadorPonte++;
                break;
            case 1:
                Ponte(-1, 0);
                contadorPonte++;
                break;
            case 2:
                Ponte(-1, 1);
                contadorPonte++;
                break;
            case 3:
                Ponte(-1, 2);
                contadorPonte++;
                break;
            case 4:
                Ponte(0, 1);
                contadorPonte++;
                break;
            case 5:
                Ponte(0, 2);
                contadorPonte++;
                break;
            case 6:
                Ponte(1, 1);
                contadorPonte++;
                break;
            case 7:
                Ponte(1, 2);
                contadorPonte++;
                Destroy(gameObject);
                break;
            default:
                Destroy(gameObject);
                Debug.Log("Limite de ponte atingido");
                break;
        }
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
        Vector3 position = new Vector3(22.5f + a, -1.5f + b, 0);
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
