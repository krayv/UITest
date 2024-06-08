using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private UIController _uiController;
    [SerializeField] private LoadSceneController _sceneController;
    [SerializeField] private SoundController _soundController;

    private EventBus _eventBus;

    private void Awake()
    {
        _eventBus = new EventBus();
        _uiController.Init(_eventBus);
        _sceneController.Init(_eventBus);
        _soundController.Init(_eventBus);
    }
}
