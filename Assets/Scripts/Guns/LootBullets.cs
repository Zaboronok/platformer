using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullets : MonoBehaviour
{
    public int gunIndex;
    public int amountOfBullets;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<PlayerArmory>();

        if (player)
        {
            player.AddBullets(gunIndex, amountOfBullets);
            Destroy(gameObject);
        }
    }
}
