using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Santé du joueur : " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("GAME OVER");
        }
    }
}