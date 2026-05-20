using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryController : MonoBehaviour
{
    
    void Start()
    {
        Invoke(nameof(GoToMap), 2.5f);
    }

    
    void GoToMap()
    {
        SceneManager.LoadScene("MapScene");
    }
}
