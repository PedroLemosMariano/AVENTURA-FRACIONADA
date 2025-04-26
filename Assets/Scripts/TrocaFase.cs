using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaFase : MonoBehaviour
{
    [SerializeField] private bool salvarPosicao;
    public string ProximaFase;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (salvarPosicao)
            {
                // Salva a posição do jogador
                PlayerPrefs.SetFloat("X", col.transform.position.x);
                PlayerPrefs.SetFloat("Y", col.transform.position.y-1f);
            }

            SceneManager.LoadScene(ProximaFase);

        }
    }
}
