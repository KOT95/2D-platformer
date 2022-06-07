using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public void OnClick(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
