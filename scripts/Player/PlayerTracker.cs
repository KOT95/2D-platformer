using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float xOffset, yOffset;
    
    private void LateUpdate()
    {
        transform.position = new Vector3(player.position.x - xOffset, player.position.y + yOffset, transform.position.z);
    }
}
