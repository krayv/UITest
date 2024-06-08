using UnityEngine;

public class SoundController : MonoBehaviour
{
    private EventBus _eventBus;

    [SerializeField]
    private AudioSource _soundAudioSource;

    [SerializeField]
    private AudioSource _musicAudioSource;

    public static bool IsMusicEnabled
    {
        get
        {
            int value = PlayerPrefs.GetInt("Music", 1);
            return value == 1;
        }
        set
        {
            PlayerPrefs.SetInt("Music", value ? 1 : 0);
        }
    }

    public static bool IsSoundsEnabled
    {
        get
        {
            int value = PlayerPrefs.GetInt("Sounds", 1);
            return value == 1;
        }
        set
        {
            PlayerPrefs.SetInt("Sounds", value ? 1 : 0);
        }
    }

    public void Init(EventBus eventBus)
    {
        _eventBus = eventBus;
        SetEvents();
        DontDestroyOnLoad(gameObject);
        UpdateSoundSource();
        UpdateMusicSource();
    }

    public void PlayClick()
    {
        _soundAudioSource.Play();
    }

    private void SetEvents()
    {
        _eventBus.OnToggleMusic += OnToggleMusic;
        _eventBus.OnToggleSound += OnToggleSound;
        _eventBus.OnClick += PlayClick;
    }

    private void OnToggleSound(bool value)
    {
        IsSoundsEnabled = value;
        UpdateSoundSource();
    }

    private void OnToggleMusic(bool value)
    {
        IsMusicEnabled = value;
        UpdateMusicSource();
    }

    private void UpdateSoundSource()
    {
        _soundAudioSource.enabled = IsSoundsEnabled;
    }

    private void UpdateMusicSource()
    {
        _musicAudioSource.enabled = IsMusicEnabled;
    }
}
