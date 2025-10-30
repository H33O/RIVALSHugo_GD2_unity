using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed = 5f;

    [Header("Damage")]
    [SerializeField] private int _damage = 1;

    private Rigidbody _rb;
    [SerializeField] private Color _blueColor;
    [SerializeField] private Color _redColor;
    [SerializeField] private Color _ChosenColor;
    [SerializeField] private AudioClip _KillerSound;
    private AudioSource _audioSource;
    public MeshRenderer meshRenderer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        if (_rb != null)
        {
            _rb.linearVelocity = transform.forward * _speed;
        }
        meshRenderer = GetComponent<MeshRenderer>();
        _ChosenColor =(Random.value < 0.5f) ? _blueColor : _redColor;
        meshRenderer.material.color = _ChosenColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blue") || other.CompareTag("Red"))
        {
            HealthSystem health = other.GetComponentInParent<HealthSystem>();
            if (health != null)
            {
                health.TakeDamage(_damage);
                _audioSource.PlayOneShot(_KillerSound);
            }
            
            Destroy(gameObject,0.1f);
            return;
        }

        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position, Vector3.one);
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2f);
    }
}