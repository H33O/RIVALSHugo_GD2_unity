using System.Collections;
using UnityEngine;

public class ZoneKill : MonoBehaviour
{
    [Header("Damage Settings")]
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _damageInterval = 1f;
    
    [Header("Lifetime")]
    [SerializeField] private float _lifetime = 5f;

    private HealthSystem _playerHealthInZone;
    private Coroutine _damageCoroutine;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _KillSound;

    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerHealthInZone = other.GetComponent<HealthSystem>();
            if (_playerHealthInZone != null)
            {
                _damageCoroutine = StartCoroutine(DamageOverTime());
                if (_audioSource != null && _KillSound != null)
                {
                    _audioSource.PlayOneShot(_KillSound);
                    Destroy(gameObject, _KillSound.length);
                    Destroy(gameObject,0.2f);
                }
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_damageCoroutine != null)
            {
                StopCoroutine(_damageCoroutine);
                _damageCoroutine = null;
            }
            _playerHealthInZone = null;
        }
    }

    private IEnumerator DamageOverTime()
    {
        while (_playerHealthInZone != null)
        {
            _playerHealthInZone.TakeDamage(_damage);
            yield return new WaitForSeconds(_damageInterval);
        }
    }
}