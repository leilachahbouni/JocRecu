using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class Ch2TimelineEnd : MonoBehaviour
{
    public string nextSceneName = "Example_01";

    private PlayableDirector director;

    void Start()
    {
        director = GetComponent<PlayableDirector>();
        if (director != null)
        {
            director.stopped += OnTimelineFinished;
        }
    }

    void OnTimelineFinished(PlayableDirector pd)
    {
        Debug.Log("✅ Timeline ch2 finalizado, cargando siguiente escena...");
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(nextSceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == nextSceneName)
        {
            GameObject ch3Object = GameObject.Find("ch3");
            if (ch3Object != null)
            {
                PlayableDirector directorCh3 = ch3Object.GetComponent<PlayableDirector>();
                if (directorCh3 != null)
                {
                    Debug.Log("▶️ Reproduciendo timeline ch3 en Example_01");
                    directorCh3.Play();
                }
                else
                {
                    Debug.LogWarning("⚠️ 'ch3' no tiene PlayableDirector");
                }
            }
            else
            {
                Debug.LogWarning("⚠️ No se encontró GameObject llamado 'ch3'");
            }

            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    void OnDestroy()
    {
        if (director != null)
            director.stopped -= OnTimelineFinished;

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
