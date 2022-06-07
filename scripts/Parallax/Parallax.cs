using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private ParallaxElement[] parallaxElements;
    [SerializeField] private float xOffset;

    private void Update()
    {
        transform.position = new Vector3(playerInput.transform.position.x - xOffset, transform.position.y, transform.position.z);
        
        if (playerInput.Horizontal != 0)
        {
            for (int i = 0; i < parallaxElements.Length; i++)
            {
                parallaxElements[i].MoveElement(playerInput.Horizontal);
            }
        }
    }
}
