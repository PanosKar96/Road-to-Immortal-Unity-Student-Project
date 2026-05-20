using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{

    public Button level1Button;
    public Button level2Button;
    public Button level3Button;

    void Start()
    {
      level1Button.interactable = false;
      level2Button.interactable = false;
      level3Button.interactable = false;

      int level = GameManager.Instance.highestUnlockedLevel;

      if(level == 0) 
      {
        level1Button.interactable = true;
      }
      else if (level == 1)
      {
        level1Button.interactable = false;
        level2Button.interactable = true;
      }
      else if (level == 2)
        {
          level1Button.interactable = false;
        level2Button.interactable = false;
         level3Button.interactable = true;
        }
    }
    public void SelectLevel1()
    {
        GameManager.Instance.currentLevel = 0;
        SceneManager.LoadScene("BattleScene");
    }

    public void SelectLevel2()
    {
        GameManager.Instance.currentLevel = 1;
        SceneManager.LoadScene("BattleScene");
    }

    public void SelectLevel3()
    {
        GameManager.Instance.currentLevel = 2;
        SceneManager.LoadScene("BattleScene");
    }
}
