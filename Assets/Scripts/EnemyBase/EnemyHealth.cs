using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1;

    public UnityEvent eventOnTakeDamage;
    public UnityEvent eventOnDie;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }

        eventOnTakeDamage.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
        eventOnDie.Invoke();
    }
}
