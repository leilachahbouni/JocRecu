using UnityEngine;

public class NPCAttackOnTouch : MonoBehaviour
{
    public int damage = 10;
    public float damageCooldown = 1.0f; // Tiempo entre daños para que no se quite de golpe
    private float lastDamageTime;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time - lastDamageTime > damageCooldown)
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                    lastDamageTime = Time.time;
                }
            }
        }
    }
}
