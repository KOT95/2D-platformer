using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
