using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTargetEuler : MonoBehaviour
{
    public float rotationSpeed;
    public Vector3 leftEuler;
    public Vector3 rightEuler;

    private Vector3 _targetEuler;

    void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetEuler), rotationSpeed * Time.deltaTime);
    }

    public void RotationLeft()
    {
        _targetEuler = leftEuler;
    }

    public void RotationRight()
    {
        _targetEuler = rightEuler;
    }
}
