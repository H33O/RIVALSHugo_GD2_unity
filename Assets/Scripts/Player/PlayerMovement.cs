using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horizontalMovement;
    private float _verticalMovement;
    private Vector3 _movement;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _bonusSpeedMultiplier = 1.35f;
    [SerializeField] private float _bonusDuration = 4f;
    
    private float _baseSpeed;
    private float _bonusSpeedEndTime;

    private Vector3 _dashDirection;
    private Vector3 _dashTarget;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _baseSpeed = _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BonusSpeed"))
        {
            _speed = _baseSpeed * _bonusSpeedMultiplier;
            _bonusSpeedEndTime = Time.time + _bonusDuration;
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        if (Time.time >= _bonusSpeedEndTime && _speed != _baseSpeed)
        {
            _speed = _baseSpeed;
        }

        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
        _movement = new Vector3(_horizontalMovement, 0f, _verticalMovement);
        _movement.Normalize();
        _movement *= _speed;
        _movement.y = _rb.linearVelocity.y;

        if (_rb != null)
        {
            _rb.linearVelocity = _movement;
        }
        else
        {
            Debug.LogError("No RigidBody Attached !");
        } 
    }
}