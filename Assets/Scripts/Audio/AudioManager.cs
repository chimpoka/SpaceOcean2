using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "ScriptableObjects / AudioManager")]
public class AudioManager : ScriptableObject
{
    public AudioClip[] MusicClipArray;
    public AudioClip[] SoundClipArray;
    public AudioClip DefaultClip;

    public float MusicVolume
    {
        get
        {
            return musicVolume;
        }
        set
        {
            musicVolume = value;
            MusicAudioSource.volume = value;
        }
    }
    public float SoundVolume
    {
        get
        {
            return soundVolume;
        }
        set
        {
            soundVolume = value;
            SoundAudioSource.volume = value;
        }
    }

    private AudioSource MusicAudioSource;
    private AudioSource SoundAudioSource;
    private GameObject AudioManagerObject;

    private float musicVolume;
    private float soundVolume;

    AudioManager()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        //MusicVolume = AudioState.MusicVolume;
        //SoundVolume = AudioState.SoundVolume;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioManagerObject = new GameObject("AudioManager");
        MusicAudioSource = AudioManagerObject.AddComponent<AudioSource>();
        SoundAudioSource = AudioManagerObject.AddComponent<AudioSource>();
    }

    private AudioClip GetSound(string clipName)
    {
        for (int i = 0; i < SoundClipArray.Length; i++)
        {
            if (SoundClipArray[i].name == clipName)
            {
                return SoundClipArray[i];
            }
        }
        Debug.LogError("Can not find clip " + clipName);
        return DefaultClip;
    }

    public void PlaySound(string clipName)
    {
        SoundAudioSource.PlayOneShot(GetSound(clipName));
    }

    public void PlayMusic(int track)
    {
        MusicAudioSource.clip = MusicClipArray[track];
        MusicAudioSource.loop = true;
        MusicAudioSource.Play();
    }
}
