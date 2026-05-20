using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.Instance.ResetRun();
        SceneManager.LoadScene("CharacterSelectScene");
    }
}