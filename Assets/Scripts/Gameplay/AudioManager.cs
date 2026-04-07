using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip reportMusic;

    [SerializeField] private AudioClip walkClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip collectibleClip;

    [SerializeField] AudioClip music;
    AudioMixerGroup musicGroup;
    AudioMixerGroup sfxGroup;
    const string MUSIC_GROUP_NAME = "Music";
    const string SFX_GROUP_NAME = "SFX";

    const string MASTER_VOLUME_NAME = "MasterVolume";
    const string MUSIC_VOLUME_NAME = "MusicVolume";
    const string SFX_VOLUME_NAME = "SFXVolume";
    private AudioSource musicSource;
    private AudioSource walkSource;

    public static AudioManager Instance { get; private set; }
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Init();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Init()
    {
        musicGroup = mixer.FindMatchingGroups(MUSIC_GROUP_NAME)[0];
        sfxGroup = mixer.FindMatchingGroups(SFX_GROUP_NAME)[0];

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.outputAudioMixerGroup = musicGroup;
        musicSource.loop = true;
        musicSource.playOnAwake = false;

        walkSource = gameObject.AddComponent<AudioSource>();
        walkSource.outputAudioMixerGroup = sfxGroup;
        walkSource.loop = true;
        walkSource.playOnAwake = false;
        walkSource.clip = walkClip;
        walkSource.volume = 0.4f;

        PlayMusic(menuMusic);
    }
private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);
        StopWalking();

        // Change these scene names to match your project exactly
        if (scene.name == "MazeGame")
        {
            PlayMusic(gameMusic, true);
        }
        else if (scene.name == "Raport")
        {
            PlayMusic(reportMusic, false);
        }
        else if (
            scene.name == "Bootstrap" ||
            scene.name == "FormInfo" ||
            scene.name == "StartGame" ||
            scene.name == "PlayInfo"
        )
        {
            PlayMusic(menuMusic, true);

            ChangeMusicVolume(0.35f);
            ChangeSFXVolume(1f);
        }
    }

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
       if (clip == null) return;

    if (musicSource.clip == clip && musicSource.isPlaying)
        return;

    musicSource.Stop();
    musicSource.clip = clip;
    musicSource.loop = loop; 
    musicSource.Play();
    }

    public enum SoundType
    {
        SFX,
        Music
    }

    public void PlaySFX(AudioClip audioClip, float volume = 1f)
    {
        if (audioClip == null) return;

        GameObject newAudioObject = new GameObject(audioClip.name + "_Source");
        AudioSource audioSource = newAudioObject.AddComponent<AudioSource>();

        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.loop = false;
        audioSource.outputAudioMixerGroup = sfxGroup;
        audioSource.Play();

        Destroy(newAudioObject, audioClip.length);
    }

    public void PlayJump()
    {
        PlaySFX(jumpClip, 1f);
    }

    public void PlayCollectible()
    {
        PlaySFX(collectibleClip, 1f);
    }

    public void StartWalking()
    {
        if (walkSource == null || walkClip == null) return;

        if (!walkSource.isPlaying)
        {
            walkSource.clip = walkClip;
            walkSource.Play();
        }
    }

    public void StopWalking()
    {
        if (walkSource != null && walkSource.isPlaying)
        {
            walkSource.Stop();
        }
    }

    public void ChangeMasterVolume(float volume)
    {
        mixer.SetFloat(MASTER_VOLUME_NAME, Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20);
    }

    public void ChangeMusicVolume(float volume)
    {
        mixer.SetFloat(MUSIC_VOLUME_NAME, Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20);
    }

    public void ChangeSFXVolume(float volume)
    {
        mixer.SetFloat(SFX_VOLUME_NAME, Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20);
    }
}
