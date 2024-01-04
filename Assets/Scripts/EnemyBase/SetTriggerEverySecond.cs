using UnityEngine;

public class SetTriggerEverySecond : MonoBehaviour
{
    public float attackPeriod = 7f;
    public Animator animator;
    public string triggerName = "Attack";

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > attackPeriod)
        {
            _timer = 0;
            animator.SetTrigger("Attack");
        }
    }
}
