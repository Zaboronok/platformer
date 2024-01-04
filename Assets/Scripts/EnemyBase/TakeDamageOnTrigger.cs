using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    public bool dieOnAnyCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<Bullet>())
            {
                enemyHealth.TakeDamage(1);
            }
        }

        if (dieOnAnyCollision && !other.isTrigger)
        {
            enemyHealth.TakeDamage(10000);
        }
    }
}
