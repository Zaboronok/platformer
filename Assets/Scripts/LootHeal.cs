using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    public int healthValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<PlayerHealth>();

        if (player)
        {
            player.AddHealth(healthValue);
            Destroy(gameObject);
        }
    }
}
