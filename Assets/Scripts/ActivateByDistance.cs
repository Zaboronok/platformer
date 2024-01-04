#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    public float distanceToActivate = 10f;

    private bool _isActive = true;
    private Activator _activator;

    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (distance < distanceToActivate && !_isActive)
        {
            Activate();
        }
        if (distance > distanceToActivate + 2 && _isActive)
        {
            Deactivate();
        }
    }

    public void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    private void Start()
    {
        _activator = FindObjectOfType<Activator>();
        _activator.objectsToActive.Add(this);
    }

    private void OnDestroy()
    {
        _activator.objectsToActive.Remove(this);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position, Vector3.forward, distanceToActivate);
    }
#endif

}
