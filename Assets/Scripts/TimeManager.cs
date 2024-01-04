using System.Xml.Serialization;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float timeScale = 0.3f;
    private float _startFixedDeltaTime;

    private void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) {
            Time.timeScale = timeScale;
        } else {             
            Time.timeScale = 1f;
        }

        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }
}
