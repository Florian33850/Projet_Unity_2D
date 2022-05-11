using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public int healthPoints = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(PlayerHealth.instance.currentHealth != PlayerHealth.instance.maxHealth)
            {
                PlayerHealth.instance.HealPlayer(healthPoints);
                Destroy(gameObject);
            }
        }
    }
}
