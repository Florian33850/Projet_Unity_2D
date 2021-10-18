using UnityEngine;

public class PickUpHealth : MonoBehaviour
{
    public int health = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            if(playerHealth.currentHealth != playerHealth.maxHealth)
            {
                playerHealth.PickUpHealth(health);
                Destroy(gameObject);
            }
        }
    }
}
