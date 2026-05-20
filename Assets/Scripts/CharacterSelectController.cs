using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectController : MonoBehaviour
{
    
    public void SelectJuggernaut()// method to select hero Juggernaut
    {
        GameManager.Instance.selectedHeroData = GameManager.Instance.juggernaut;
        SceneManager.LoadScene("MapScene");// load the map scene
    }

    public void SelectDrow()
    {
        GameManager.Instance.selectedHeroData = GameManager.Instance.drow;
        SceneManager.LoadScene("MapScene");
    }

    public void SelectKotl()
    {
        GameManager.Instance.selectedHeroData = GameManager.Instance.kotl;
        SceneManager.LoadScene("MapScene");
    }
}
