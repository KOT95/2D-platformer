using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float lerpDuraction = 1;
    [SerializeField] private Health playerHealth;
    [SerializeField] private GameObject gameoverPanel;

    private List<Heart> hearts = new List<Heart>();
    private float _maxHealth;
    private float _currentHealth;

    private void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if(gameObject.transform.GetChild(i).GetComponent<Heart>())
                hearts.Add(gameObject.transform.GetChild(i).GetComponent<Heart>());
        }
        
        StartCoroutine(FillHearts());
        
        _maxHealth = hearts.Count;
        _currentHealth = _maxHealth;
    }
    
    private void OnEnable()
    {
        playerHealth.Damage += OnDamage;
    }

    private void OnDisable()
    { 
        playerHealth.Damage -= OnDamage;
    }

    private IEnumerator FillHearts()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (!hearts[i].gameObject.activeSelf)
            {
                hearts[i].gameObject.SetActive(true);
                hearts[i].ToFill(lerpDuraction);
                yield return new WaitForSeconds(lerpDuraction);
            }
        }
    }

    private void OnDamage(int damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;

            for (int i = 0; i < hearts.Count; i++)
            {
                if(i < _currentHealth || !hearts[i].gameObject.activeSelf)
                    continue;
                
                hearts[i].ToEmpty(lerpDuraction);
                
                if(_currentHealth <= 0)
                    GameOver();
            }
        }
    }

    private void GameOver()
    {
        playerHealth.Dead();
        gameoverPanel.SetActive(true);
    }
}
