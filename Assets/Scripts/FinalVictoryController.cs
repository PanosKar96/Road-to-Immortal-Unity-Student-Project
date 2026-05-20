using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalVictoryController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void BackToMainMenu()
    {
        GameManager.Instance.currentLevel = 0;
        GameManager.Instance.highestUnlockedLevel = 0;

        SceneManager.LoadScene("StartScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
