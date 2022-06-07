using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 4;

    private Health _health;

    private void OnEnable()
    {
        _health = GetComponent<Health>();
        GetComponent<Health>().Damage += OnDamage;
    }

    private void OnDisable()
    {
        GetComponent<Health>().Damage -= OnDamage;
    }

    private void OnDamage(int damage)
    {
        health -= damage;
        
        if(health <= 0)
            _health.Dead();
    }
}
