using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 7f;
    public float rotationSpeed = 3f;

    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
