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
    [SerializeField] private float _speed = 2f;
    private float _SQRmagnitude;
    private Vector3 _Grapindirection;
    private Vector3 _GrapinHit;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
        _movement = new Vector3(_horizontalMovement, 0f, _verticalMovement);
        GrappinUpdateDirection(_movement);
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

        if (Input.GetKeyDown(KeyCode.G))
        {
            TryThrowGrapin();
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            throwGrapin();
        }
    }

    private void GrappinUpdateDirection(Vector3 direction)
    {
        if(direction.sqrMagnitude > 0.1f)
        {
            _Grapindirection = direction;
        }
        
    }

    private void TryThrowGrapin()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,
            _Grapindirection, out hit,100f))
        {
            _GrapinHit = hit.point+hit.normal*1.5f;
        }
    }

    private void throwGrapin()
    {
        transform.position = _GrapinHit;
        _Grapindirection = Vector3.zero;
    }
}