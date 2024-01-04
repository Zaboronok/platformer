using UnityEngine;

public class Acorn : MonoBehaviour
{
    public Vector3 velocity;
    public float maxRotationSpeed;

    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(velocity, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(
            Random.Range(-maxRotationSpeed, maxRotationSpeed),
            Random.Range(-maxRotationSpeed, maxRotationSpeed),
            Random.Range(-maxRotationSpeed, maxRotationSpeed)
            );
    }
}
