using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviorBlue : MonoBehaviour
{
    [SerializeField] private int _targetValue = 1;
    [SerializeField] private AudioClip _eatSound;
    [SerializeField] private AudioClip _loseSound;
    private bool hasCollided = false;
    private AudioSource _audioSource;
    

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasCollided) return;

        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
            return;
        } 
        
        if (other.CompareTag("Blue"))
        {
            Debug.Log("Blue");
            if (other.gameObject.GetComponent<Player_Collect>() != null)
            {
                hasCollided = true;
                other.gameObject.GetComponent<Player_Collect>().UpdateScore(1);
                
                if (_audioSource != null && _eatSound != null)
                {
                    _audioSource.PlayOneShot(_eatSound);
                    Destroy(gameObject, _eatSound.length);
                    Destroy(gameObject,0.2f);
                }
                
            }
        }
        else if (other.CompareTag("Red"))
        {
            Debug.Log("Red");
            if (other.gameObject.GetComponent<Player_Collect>() != null)
            {
                hasCollided = true;
                other.gameObject.GetComponent<Player_Collect>().UpdateScore(-1);
                if (_audioSource != null && _loseSound != null)
                {
                    _audioSource.PlayOneShot(_loseSound);
                }
            }
        }
    }
}