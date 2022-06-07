using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private int damage = 1;
    
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
