using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetarUpdates : MonoBehaviour
{
    private void Start()
    {
        // Resetar PlayerPrefs para testes
        PlayerPrefs.SetInt("moedaX2", 0);
        PlayerPrefs.SetInt("agilidade", 0);
        PlayerPrefs.SetFloat("X", 0f);
        PlayerPrefs.SetFloat("Y", 0f);
    }
}
