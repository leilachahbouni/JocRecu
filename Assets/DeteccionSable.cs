using UnityEngine;
using UnityEngine.Playables;

public class SableTrigger : MonoBehaviour
{
    public GameObject personajeJugable;
    public GameObject personajeAnimado;
    public PlayableDirector playableDirector;
    private bool activado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activado) return;

        // Verifica si el objeto que entra tiene CharacterController (tu jugador)
        if (other.GetComponent<CharacterController>() != null)
        {
            activado = true;

            gameObject.SetActive(false); // Desactiva el sable
            personajeJugable.SetActive(false); // Desactiva el personaje jugable
            personajeAnimado.SetActive(true); // Activa personaje animado

            if (playableDirector != null)
                playableDirector.Play();
        }
    }
}
