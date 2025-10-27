using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private AudioClip _LoseSound;
    [SerializeField] private GameObject _loseCanvas;   
    public static Action<int> onHealthChanged;
    public static Action onPlayerDied;
    private AudioSource _audioSource;
    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        onHealthChanged?.Invoke(_currentHealth);
        _loseCanvas.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        
        onHealthChanged?.Invoke(_currentHealth);
        
        Debug.Log("Vie restante : " + _currentHealth);
        
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        
        onHealthChanged?.Invoke(_currentHealth);
    }

    private void Die()
    {
        _loseCanvas.SetActive(true);
        _audioSource.PlayOneShot(_LoseSound);
        
        Time.timeScale = 0f;
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }
}