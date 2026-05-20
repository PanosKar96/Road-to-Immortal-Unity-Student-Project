using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    
    public AudioSource musicSource;
    [Header("Music Tracks")]
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    
    void Awake()
    {
        // Singleton pattern - only one MusicManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            
            // Start with menu music
            PlayMenuMusic();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayMenuMusic()
    {
        if (musicSource != null && menuMusic != null)
        {
            // Only change if different track
            if (musicSource.clip != menuMusic || !musicSource.isPlaying)
            {
                musicSource.clip = menuMusic;
                musicSource.Play();
            }
        }
    }
    
    public void PlayGameMusic()
    {
        if (musicSource != null && gameMusic != null)
        {
            // Only change if different track
            if (musicSource.clip != gameMusic || !musicSource.isPlaying)
            {
                musicSource.clip = gameMusic;
                musicSource.Play();
            }
        }
    }
    
    // This is called by OptionsController
    public void SetVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = Mathf.Clamp01(volume);
        }
    }
}