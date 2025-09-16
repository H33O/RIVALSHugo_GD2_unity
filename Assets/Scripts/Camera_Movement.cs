using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    private float _horizontalMovement;
    private float _verticalMovement;
    private Vector3 _movement;
    [SerializeField] private float speed; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
        _movement = new Vector3(_horizontalMovement, 0, _verticalMovement);
        _movement.Normalize();
        _movement *= speed;
    }
}
