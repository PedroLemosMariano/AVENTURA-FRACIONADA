using UnityEngine;
using UnityEngine.SceneManagement;
using static PowerupsAtivos;

public class ResetarUpdates : MonoBehaviour
{
    void OnEnable()
    {
        PowerUpsAtivos.moedaX2 = false;
        PowerUpsAtivos.agilidade = false;
        Debug.Log("Power-ups resetados ao iniciar a cena.");
    }

    // Opcional: Resetar quando a cena for carregada
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) => ResetarPowerUps();

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        ResetarPowerUps();
    }

    void OnDestroy() => SceneManager.sceneLoaded -= OnSceneLoaded;

    public void ResetarPowerUps()
    {
        PowerUpsAtivos.moedaX2 = false;
        PowerUpsAtivos.agilidade = false;
    }
}
