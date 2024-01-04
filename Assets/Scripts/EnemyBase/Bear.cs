using UnityEngine;

public class Bear : MonoBehaviour
{
    public float attackPeriod = 7f;
    public Animator animator;

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > attackPeriod)
        {
            _timer = 0;
            animator.SetTrigger("Attack");
        }
    }
}
