using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    [SerializeField] AudioSource _SFX;
    [SerializeField] AudioSource _SFXR;
    [SerializeField] AudioSource _Music;

    public float LowV = .90f;
    public float HighV = 1.05f;

    public void PlaySFX(AudioClip clip)
    {
        _SFX.clip = clip;
        _SFX.Play();
    }
    public void PlayMusic(AudioClip clip)
    {
        _Music.clip = clip;
        _Music.Play();
    }

    public void ArrayRandomisedSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowV, HighV);
        _SFXR.pitch = randomPitch;
        _SFXR.clip = clips[randomIndex];
        _SFXR.Play();
    }
}
