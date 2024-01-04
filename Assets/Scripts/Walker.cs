using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    public Transform leftTarget;
    public Transform rightTarget;
    public float speed;
    public float stopTime;
    public Direction currentDirection;

    public UnityEvent eventOnLeftTarget;
    public UnityEvent eventOnRightTarget;
    public Transform rayStart;

    private bool _isStopped;

    private void Start()
    {
        leftTarget.parent = null;
        rightTarget.parent = null;
    }

    void Update()
    {
        if (_isStopped)
        {
            return;
        }


        if (currentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * speed, 0f, 0f);

            if (transform.position.x < leftTarget.position.x)
            {
                currentDirection = Direction.Right;
                _isStopped = true;
                Invoke("ContinueWalk", stopTime);
                eventOnLeftTarget.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0f, 0f);

            if (transform.position.x > rightTarget.position.x)
            {
                currentDirection = Direction.Left;
                _isStopped = true;
                Invoke("ContinueWalk", stopTime);
                eventOnRightTarget.Invoke();
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(rayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }

    void ContinueWalk()
    {
        _isStopped = false;
    }
}
