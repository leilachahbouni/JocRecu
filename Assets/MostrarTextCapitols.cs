using UnityEngine;
using UnityEngine.Playables;
using TMPro;
using System.Collections;

public class MostrarTextCapitols : MonoBehaviour
{
    public PlayableDirector director;
    public TextMeshProUGUI textCapitol;

    private bool jaAcabat = false;

    void Update()
    {
        if (!jaAcabat && director.state != PlayState.Playing)
        {
            jaAcabat = true;
            StartCoroutine(MostrarTextos());
        }
    }

    IEnumerator MostrarTextos()
    {
        textCapitol.gameObject.SetActive(true);

        // Text 1
        textCapitol.text = "Fi del Capítol 1";
        yield return new WaitForSeconds(3f);

        // Text 2
        textCapitol.text = "Capítol 2: Inici del Fi";
        yield return new WaitForSeconds(3f);

        // Si vols ocultar el text després
        textCapitol.gameObject.SetActive(false);

        // Aquí pots carregar nova escena o activar coses del capítol 2
    }
}
