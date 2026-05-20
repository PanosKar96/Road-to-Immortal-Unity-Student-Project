using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonHandler : MonoBehaviour
{
    public string gameSceneName = "GameScene"; // Change to your game scene name
    
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnPlayButtonClicked);
        }
    }
    
    void OnPlayButtonClicked()
    {
        // 1. Switch to game music BEFORE loading scene
        if (MusicManager.instance != null)
        {
            MusicManager.instance.PlayGameMusic();
        }
        
        // 2. Load the game scene
        if (!string.IsNullOrEmpty(gameSceneName))
        {
            // Optional: Add a small delay to hear music transition
            Invoke(nameof(LoadGameScene), 0.1f);
        }
        else
        {
            Debug.LogWarning("No game scene name assigned!");
        }
    }
    
    void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}