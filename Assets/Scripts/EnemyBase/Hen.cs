using UnityEngine;

public class Hen : MonoBehaviour
{
    public Rigidbody rigidbody;

    private Transform _player;

    [SerializeField] float speed = 4f;
    [SerializeField] float timeTo = 0.2f;

    private void Start()
    {
        _player = FindObjectOfType<PlayerMove>().transform;
    }

    private void FixedUpdate()
    {
        var toPlayer = (_player.position - transform.position).normalized;
        var force = rigidbody.mass * (toPlayer * speed - rigidbody.velocity) / timeTo;

        rigidbody.AddForce(force);
    }
}
