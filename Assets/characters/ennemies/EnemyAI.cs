using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Animator anim; // Nouvelle variable pour l'Animator

    void Update()
    {
        if (player != null)
        {
            // L'ennemi se déplace vers le joueur
            agent.SetDestination(player.position);

            // GESTION DE L'ANIMATION
            // Si la vitesse de l'agent est supérieure à 0.1, on active la course
            if (agent.velocity.magnitude > 0.1f)
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
        }
    }
}