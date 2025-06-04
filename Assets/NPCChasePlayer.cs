using UnityEngine;
using UnityEngine.AI;

public class NPCChasePlayer : MonoBehaviour
{
    public Transform player;            // Referencia al jugador
    public float detectionRadius = 10f; // Distancia a la que el NPC detecta y persigue al jugador
    public float stopDistance = 1.5f;   // Distancia a la que el NPC deja de avanzar para no chocar

    private NavMeshAgent agent;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("NPCChasePlayer: No se asignó el jugador.");
            enabled = false;
            return;
        }

        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NPCChasePlayer: No hay NavMeshAgent en el NPC.");
            enabled = false;
            return;
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRadius)
        {
            // Persigue al jugador
            agent.stoppingDistance = stopDistance;
            agent.SetDestination(player.position);
        }
        else
        {
            // El jugador está fuera de rango, se detiene
            agent.ResetPath();
        }
    }

    // Para visualizar el radio de detección en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
