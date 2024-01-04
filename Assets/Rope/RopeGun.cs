using UnityEngine;
using UnityEngine.UIElements;

public class RopeGun : MonoBehaviour
{
    public Hook hook;
    public Transform spawn;
    public float speed;
    public SpringJoint springJoint;
    public Transform ropeStart;
    public RopeRenderer ropeRenderer;
    public PlayerMove playerMove;

    private float _length;

    [SerializeField] private RopeState _currentRopeState;

    public void CreateSpring()
    {
        if (springJoint == null) {
            springJoint = gameObject.AddComponent<SpringJoint>();
            springJoint.connectedBody = hook.rigidbody;
            springJoint.anchor = ropeStart.localPosition;
            springJoint.autoConfigureConnectedAnchor = false;
            springJoint.connectedAnchor = Vector3.zero;
            springJoint.spring = 100f;
            springJoint.damper = 5f;

            _length = Vector3.Distance(ropeStart.position, hook.transform.position);
            springJoint.maxDistance = _length;
            _currentRopeState = RopeState.Active;
        }
    }

    public void DestroySpring()
    {
        if (springJoint)
        {
            Destroy(springJoint);
            _currentRopeState = RopeState.Disabled;
            hook.gameObject.SetActive(false);
            ropeRenderer.Hide();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2)) {
            Shot();
        }

        if (_currentRopeState == RopeState.Fly) {
            float distance = Vector3.Distance(ropeStart.position, hook.transform.position);

            if (distance > 20f) {
                hook.gameObject.SetActive(false);
                _currentRopeState = RopeState.Disabled;
                ropeRenderer.Hide();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (_currentRopeState == RopeState.Active && !playerMove.grounded) {
                playerMove.Jump();
            }

            DestroySpring();
        }

        if (_currentRopeState == RopeState.Fly || _currentRopeState == RopeState.Active) {
            ropeRenderer.Draw(ropeStart.position, hook.transform.position, _length);
        }
    }

    void Shot()
    {
        if (springJoint) {
            Destroy(springJoint);
        }

        _length = 1f;
        hook.gameObject.SetActive(true);
        hook.StopFix();
        hook.transform.position = spawn.position;
        hook.transform.rotation = spawn.rotation;
        hook.rigidbody.velocity = spawn.forward * speed;
        _currentRopeState = RopeState.Fly;
    }
}
