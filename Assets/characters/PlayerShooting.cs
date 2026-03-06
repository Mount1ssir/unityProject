using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float range = 100f; // Distance max du tir
    public Camera cam;         // Ta Main Camera
    public float damage = 25f; // Dégâts infligés à chaque clic

    void Update()
    {
        // Déclenche le tir lors du clic gauche
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        // Envoie un rayon du centre de la caméra vers l'avant
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log("Objet touché : " + hit.transform.name);

            // Cherche si l'objet touché a le script EnemyHealth
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Inflige les dégâts
            }
        }
    }
}