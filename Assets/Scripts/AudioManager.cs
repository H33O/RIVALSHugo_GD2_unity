using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _GameMusic;
    private AudioSource _AudioSource;
    void Start()
    {
        if (_GameMusic != null && _GameMusic != null)
        {
            _AudioSource.PlayOneShot(_GameMusic);
        }
    }

    
}
