using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private int nextLevel;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerInput _player))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
