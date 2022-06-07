using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystemPrefab;
    public event Action<int> Damage = default;

    private GameObject _obj;

    private void Start()
    {
        _obj = gameObject;
    }

    public void TakeDamage(int damage)
    {
        if (Damage != null)
            Damage(damage);
    }

    public void Dead()
    {
        ParticleSystem ps = Instantiate(particleSystemPrefab, _obj.transform.position, Quaternion.identity);
        Destroy(ps.gameObject, 1);
        _obj.SetActive(false);
    }
}
