using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{    
    public int damageValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            var player = other.attachedRigidbody.GetComponent<PlayerHealth>();

            if (player)
            {
                player.TakeDamage(damageValue);
            }
        }
    }
}
