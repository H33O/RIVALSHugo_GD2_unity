using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Rigidbody _rb;
    private Vector3 _moveDirection;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _moveDirection = transform.forward;
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = _rb.position + _moveDirection * _speed * Time.fixedDeltaTime;
        _rb.MovePosition(newPosition);
    }
}