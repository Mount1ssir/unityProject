using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Tu peux ajouter une animation de mort ici plus tard
        Destroy(gameObject);
    }
}