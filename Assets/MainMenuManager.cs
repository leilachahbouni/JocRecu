using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("LowPolyFPS_Lite_Demo");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Busca el GameObject llamado "ch1" y su PlayableDirector
        GameObject ch1Object = GameObject.Find("ch1");
        if (ch1Object != null)
        {
            PlayableDirector director = ch1Object.GetComponent<PlayableDirector>();
            if (director != null)
            {
                Debug.Log("✅ Reproduciendo Timeline ch1 desde MainMenuManager");
                director.Play();
            }
            else
            {
                Debug.LogWarning("⚠️ El objeto 'ch1' no tiene un PlayableDirector.");
            }
        }
        else
        {
            Debug.LogWarning("⚠️ No se encontró ningún GameObject llamado 'ch1'.");
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }
}
