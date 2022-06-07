using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ParallaxElement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private RawImage _image;
    private float _imagePositionX;

    private void Start()
    {
        _image = GetComponent<RawImage>();
    }

    public void MoveElement(float _horizontal)
    {
        if(_horizontal > 0)
            _imagePositionX += speed * Time.deltaTime;
        else if (_horizontal < 0)
            _imagePositionX -= speed * Time.deltaTime;
        
        _image.uvRect = new Rect(_imagePositionX, 0, _image.uvRect.width, _image.uvRect.height);
    }
}
