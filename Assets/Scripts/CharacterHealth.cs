using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public bool isPlayer;

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log(gameObject.name + " começou com " + currentHealth + " de vida.");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log(gameObject.name + " tomou " + damage + " de dano. Vida atual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log(gameObject.name + " morreu!");

        gameObject.SetActive(false);
    }
}