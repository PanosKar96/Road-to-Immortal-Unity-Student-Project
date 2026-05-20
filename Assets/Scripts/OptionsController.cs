using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider musicSlider;
    public Toggle muteToggle;
    public GameObject optionsPanel;
    
    private bool isMuted = false;
    private float savedVolume = 1f;
    
    void Start()
    {
        // Load saved settings
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            musicSlider.value = savedVolume;
            SetMusicVolume(savedVolume);
        }
        else
        {
            musicSlider.value = 1f;
            SetMusicVolume(1f);
        }
        
        if (PlayerPrefs.HasKey("MusicMuted"))
        {
            isMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
            muteToggle.isOn = isMuted;
            ApplyMuteState(isMuted);
        }
        
        // Close panel at start
        if (optionsPanel != null)
            optionsPanel.SetActive(false);
        
        // Setup listeners
        musicSlider.onValueChanged.AddListener(OnVolumeChanged);
        muteToggle.onValueChanged.AddListener(OnMuteChanged);
    }
    
    void OnVolumeChanged(float volume)
    {
        // Only change volume if not muted
        if (!isMuted)
        {
            SetMusicVolume(volume);
            savedVolume = volume;
        }
    }
    
    void OnMuteChanged(bool muted)
    {
        isMuted = muted;
        ApplyMuteState(muted);
        
        // Save state
        PlayerPrefs.SetInt("MusicMuted", muted ? 1 : 0);
        PlayerPrefs.Save();
    }
    
    void SetMusicVolume(float volume)
    {
        // This ONLY affects music via MusicManager
        if (MusicManager.instance != null)
        {
            MusicManager.instance.SetVolume(volume);
        }
        
        // Save
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }
    
    void ApplyMuteState(bool muted)
    {
        if (muted)
        {
            // Mute only music
            if (MusicManager.instance != null)
            {
                MusicManager.instance.SetVolume(0f);
            }
            musicSlider.interactable = false;
        }
        else
        {
            // Unmute with saved volume
            SetMusicVolume(savedVolume);
            musicSlider.interactable = true;
        }
    }
    
    public void OpenOptions()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(true);
    }
    
    public void CloseOptions()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(false);
    }
}