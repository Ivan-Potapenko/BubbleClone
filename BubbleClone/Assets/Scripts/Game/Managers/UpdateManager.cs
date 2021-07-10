using UnityEngine;
using Events;

public class UpdateManager : MonoBehaviour
{
    [SerializeField]
    private EventDispatcher _updateEventDispatcher;

    [SerializeField]
    private EventDispatcher _fixedUpdateEventDispatcher;

    private void Update()
    {
        _updateEventDispatcher.Dispatch();
    }

    private void FixedUpdate()
    {
        _fixedUpdateEventDispatcher.Dispatch();
    }
}
