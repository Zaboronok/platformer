using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float speed = 1f;

    void Start()
    {
        transform.rotation = Quaternion.identity;
        var playerTransform = FindObjectOfType<PlayerMove>().transform;
        var toPlayer = (playerTransform.position - transform.position).normalized;
        rigidbody.velocity = toPlayer * speed;
    }
}
