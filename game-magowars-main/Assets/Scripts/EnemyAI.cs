using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform playerTarget;

    public float shotForce = 10f;
    public float aimError = 1.5f;

    public void ShootAtPlayer()
    {
        if (playerTarget == null) return;

        Vector2 targetPosition = playerTarget.position;

        targetPosition.x += Random.Range(-aimError, aimError);
        targetPosition.y += Random.Range(-aimError, aimError);

        Vector2 direction = targetPosition - (Vector2)firePoint.position;
        direction.Normalize();

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.SetOwner(gameObject);
        }

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * shotForce, ForceMode2D.Impulse);

        Debug.Log("Inimigo atirou.");
    }
}