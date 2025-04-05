using UnityEngine;
using UnityEngine.UI;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager Instance;

    private static AudioSource audioSource;
    private static AudioSource randomPitchAudioSource;
    private static AudioSource voiceAudioSource;
    private static AudioSource backGroundAudioSource;
    private static SoundEffectLibrary soundEffectLibrary;

    [SerializeField] private Slider sfxSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            AudioSource[] audioSources = GetComponents<AudioSource>();

            if (audioSources.Length >= 4)
            {
                audioSource = audioSources[0];
                randomPitchAudioSource = audioSources[1];
                voiceAudioSource = audioSources[2];
                backGroundAudioSource = audioSources[3];
            }
            else
            {
                Debug.LogError("SoundEffectManager: Número insuficiente de AudioSources. São necessários 4.");
            }

            soundEffectLibrary = GetComponent<SoundEffectLibrary>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Play(string soundName, bool randomPitch = false)
    {
        AudioClip audioClip = soundEffectLibrary.GetRandomClip(soundName);
        if (audioClip != null)
        {
            if (randomPitch)
            {
                randomPitchAudioSource.pitch = Random.Range(1.2f, 1.5f);
                randomPitchAudioSource.PlayOneShot(audioClip);
            }
            else
            {
                audioSource.PlayOneShot(audioClip);
            }
        }
    }

    public static void PlayBackgroundMusic(AudioClip clip)
    {
        if (backGroundAudioSource != null && clip != null)
        {
            backGroundAudioSource.clip = clip;
            backGroundAudioSource.loop = true;
            backGroundAudioSource.Play();
        }
    }

    public static void PlayVoice(AudioClip audioClip, float pitch = 1f)
    {
        if (audioClip != null)
        {
            voiceAudioSource.pitch = pitch;
            voiceAudioSource.PlayOneShot(audioClip);
        }
    }

    void Start()
    {
        sfxSlider.onValueChanged.AddListener(delegate { OnValueChanged(); });

        AudioClip backgroundClip = soundEffectLibrary.GetRandomClip("BackGround");
        PlayBackgroundMusic(backgroundClip);
    }


    public static void SetVolume(float volume)
    {
        if (audioSource != null) audioSource.volume = volume;
        if (randomPitchAudioSource != null) randomPitchAudioSource.volume = volume;
        if (voiceAudioSource != null) voiceAudioSource.volume = volume;
        if (backGroundAudioSource != null) backGroundAudioSource.volume = volume;
    }

    public void OnValueChanged()
    {
        SetVolume(sfxSlider.value);
    }
}
