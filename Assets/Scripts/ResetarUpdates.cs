using System;
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

        for (int i = 0; i < 20; i++)
        {
            PlayerPrefs.SetInt("Chest_" + i, 0);
            PlayerPrefs.Save();
        }
    }
}
