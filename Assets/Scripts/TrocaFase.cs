using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaFase : MonoBehaviour
{
    public string ProximaFase;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(ProximaFase);
        }
    }
}
