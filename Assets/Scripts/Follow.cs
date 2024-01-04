using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Target;

    [SerializeField]
    private float _lerpRate = 5f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * _lerpRate);
    }
}
