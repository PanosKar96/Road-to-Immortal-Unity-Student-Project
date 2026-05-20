using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void Retry()
    {
        // Retry the SAME level, but start with full HP
        GameManager.Instance.ForceFullHPNextBattle();
        SceneManager.LoadScene("BattleScene");
    }

    public void BackToMainMenu()
    {
        // New run from scratch
        GameManager.Instance.ResetRun();
        SceneManager.LoadScene("StartScene");
    }
}
