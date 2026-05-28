using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    public float forceMultiplier = 2f;
    public float maxForce = 18f;
    public float minForce = 3f;

    public bool canShoot = true;

    public TurnManager turnManager;

    private Vector3 startMousePosition;
    private Vector3 endMousePosition;

    void Update()
    {
        if (!canShoot) return;

        if (Input.GetMouseButtonDown(0))
        {
            startMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startMousePosition.z = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endMousePosition.z = 0;

            Shoot();

            canShoot = false;

            if (turnManager != null)
            {
                turnManager.EndPlayerTurn();
            }
        }
    }

    void Shoot()
    {
        Vector2 direction = startMousePosition - endMousePosition;

        float force = direction.magnitude * forceMultiplier;
        force = Mathf.Clamp(force, minForce, maxForce);

        direction.Normalize();

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.SetOwner(gameObject);
        }

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }
}