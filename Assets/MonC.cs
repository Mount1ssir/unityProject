using UnityEngine;

public class MonC : MonoBehaviour
{
    [Header("Composants")]
    public CharacterController controller; // Glissez le Character Controller ici
    public Animator anim;               // Glissez votre modèle Y Bot ici

    [Header("Paramètres de Mouvement")]
    public float speed = 6f;            // Vitesse de déplacement
    public float gravity = -9.81f;      // Force de la gravité
    Vector3 velocity;                   // Vecteur de chute libre

    void Update()
    {
        // 1. GESTION DE LA GRAVITÉ AU SOL
        // On vérifie si le joueur touche le sol pour réinitialiser la vitesse de chute
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Petite force pour rester plaqué au sol
        }

        // 2. LECTURE DES ENTRÉES CLAVIER
        // ZQSD ou les flèches directionnelles
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 3. CALCUL ET APPLICATION DU MOUVEMENT
        // On se déplace par rapport à l'orientation du personnage (forward/right)
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // 4. GESTION DES ANIMATIONS
        // Si la magnitude du mouvement est supérieure à 0.1, on joue l'animation de marche
        if (move.magnitude > 0.1f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        // 5. APPLICATION DE LA GRAVITÉ FINALE
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}