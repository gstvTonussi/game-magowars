using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 25;
    public float lifeTime = 5f;

    private GameObject owner;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetOwner(GameObject shooter)
    {
        owner = shooter;

        Collider2D projectileCollider = GetComponent<Collider2D>();
        Collider2D ownerCollider = owner.GetComponent<Collider2D>();

        if (projectileCollider != null && ownerCollider != null)
        {
            Physics2D.IgnoreCollision(projectileCollider, ownerCollider);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == owner)
        {
            return;
        }

        CharacterHealth health = collision.gameObject.GetComponent<CharacterHealth>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}