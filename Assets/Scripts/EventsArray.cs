using UnityEngine;
using UnityEngine.Events;

public class EventsArray : MonoBehaviour
{
    public UnityEvent[] unityEvents;

    public void StartEvent(int eventIndex)
    {
        unityEvents[eventIndex].Invoke();
    }
}
