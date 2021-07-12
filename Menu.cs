using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }
    
    public void QuitApplication()
    {
        GameManager.Instance.QuitApplication();
    }
    
}
