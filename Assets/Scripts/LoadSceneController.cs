using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneController : MonoBehaviour
{
    public const string MAIN_SCENE_NAME = "Main";

    private EventBus _eventBus;

    public void Init(EventBus eventBus)
    {
        _eventBus = eventBus;
    }

    private void SetEvents()
    {
        _eventBus.OnStartLoadScene += OnStartLoadScene;
        SceneManager.sceneLoaded += OnLoadScene;
        DontDestroyOnLoad(gameObject);
    }

    private void OnStartLoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnLoadScene(Scene scene, LoadSceneMode sceneMode)
    {
        _eventBus.OnLoadScene?.Invoke(scene.name);
    }
}
