 using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}

public class Hook : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Collider collider;
    public Collider playerCollider;
    public RopeGun ropeGun;    

    private FixedJoint _fixedJoint;

    public void StopFix()
    {
        if (_fixedJoint) {
            Destroy(_fixedJoint);
        }
    }

    private void Start()
    {
        Physics.IgnoreCollision(collider, playerCollider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_fixedJoint == null) {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();

            if (collision.rigidbody) {
                _fixedJoint.connectedBody = collision.rigidbody;
            }

            ropeGun.CreateSpring();
        }
    }
}
