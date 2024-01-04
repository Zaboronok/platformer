using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rigidbodyPlayer;
    public Transform colliderTransform;
    public bool grounded;

    [SerializeField]
    private float _moveSpeed = 6f;
    [SerializeField]
    private float _jumpSpeed = 11f;
    [SerializeField]
    private float _friction = 1f;

    private float _angle = 50f;
    private float _maxSpeed = 10f;
    private int _jumpFrameCounter;

    public void Jump() { 
        rigidbodyPlayer.AddForce(0, _jumpSpeed, 0, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || !grounded)
        {
            colliderTransform.localScale = Vector3.Lerp(colliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * _moveSpeed);
        } else
        {
            colliderTransform.localScale = Vector3.Lerp(colliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * _moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if(!grounded)
        {
            speedMultiplier = 0.2f;

            if ((rigidbodyPlayer.velocity.x > _maxSpeed && Input.GetAxis("Horizontal") > 0)
            || (rigidbodyPlayer.velocity.x < -_maxSpeed && Input.GetAxis("Horizontal") < 0))
            {
                speedMultiplier = 0f;
            }
        }

        rigidbodyPlayer.AddForce(Input.GetAxis("Horizontal") * _moveSpeed * speedMultiplier, 0f, 0f, ForceMode.VelocityChange);

        if (grounded) {
            rigidbodyPlayer.AddForce(-rigidbodyPlayer.velocity.x * _friction, 0f, 0f, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);
        }

        _jumpFrameCounter += 1;
        if (_jumpFrameCounter == 2) {
            rigidbodyPlayer.freezeRotation = false;
            rigidbodyPlayer.AddRelativeTorque(0f, 0f, 20f, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);

        if (angle < _angle)
        {
            grounded = true;
            rigidbodyPlayer.freezeRotation = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
