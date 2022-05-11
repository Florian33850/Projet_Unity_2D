using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invincibilityTimeAfterHit = 3f;
    public float invincibilityFlashDelay = 0.2f;
    public bool isInvicible = false;

    public SpriteRenderer graphics;
    public HealthBar healthBar;

    public static PlayerHealth instance;

    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(60);
        }
    }

    public void TakeDamage(int damage)
    {
        if(!isInvicible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            // Vérifier si le joueur est toujours vivant
            if(currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvicible = true;
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    private void Die() 
    {
        Debug.Log("Le joueur est mort !");
        // Bloquer les mouvements du personnage
        PlayerMovement.instance.enabled = false;
        // Joueur l'animation d'élimination
        PlayerMovement.instance.animator.SetTrigger("Die");
        // Empêcher les interactions physiques avec les éléments de la scène
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public void HealPlayer(int amount)
    {
        if((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            currentHealth += amount;
            healthBar.SetHealth(currentHealth);
        }
    }

    public IEnumerator InvicibilityFlash()
    {
        while(isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay(){
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvicible = false;
    }
}
