using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    public bool dieOnAnyCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<Bullet>())
            {
                enemyHealth.TakeDamage(1);
            }
        }

        if (dieOnAnyCollision)
        {
            enemyHealth.TakeDamage(10000);
        }
    }
}
