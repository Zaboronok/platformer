using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public List<ActivateByDistance> objectsToActive = new List<ActivateByDistance>();
    public Transform playerTransform;

    void Update()
    {
        for (int i = 0; i < objectsToActive.Count; i++)
        {
            objectsToActive[i].CheckDistance(playerTransform.position);
        }
    }
}
