using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Ch2TimelineEnd : MonoBehaviour
{
    public string nextSceneName = "NombreDeLaSiguienteEscena";

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
        SceneManager.LoadScene(nextSceneName);
    }

    void OnDestroy()
    {
        if (director != null)
        {
            director.stopped -= OnTimelineFinished;
        }
    }
}
