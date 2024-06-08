using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private UIController _uiController;

    private EventBus _eventBus;

    private void Awake()
    {
        _eventBus = new EventBus();
        _uiController.Init(_eventBus);
    }
}
