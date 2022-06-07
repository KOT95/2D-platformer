using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private int duraction;
    [SerializeField] private Color targetColor;
    
    private SpriteRenderer _target;
    private Color _startColor;
    private float _time;
    private bool _go;
    
    
    private void Start()
    {
        _target = GetComponent<SpriteRenderer>();
        _startColor = _target.color;
    }
    
    private void Update()
    {
        if (_time <= duraction && _go)
        {
            _time += Time.deltaTime;
            float normalizeTime = _time / duraction;

            _target.color = Color.Lerp(_startColor, targetColor, normalizeTime);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerInput _player))
        {
            _go = true;
        }
    }
}
