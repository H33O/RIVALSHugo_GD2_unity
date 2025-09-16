using UnityEngine;
using UnityEngine.UIElements;

public class Camera_Movement : MonoBehaviour
{
   
    private float _horizontalMovement;
    private float _verticalMovement;
    private Vector3 _rotation;
    [SerializeField]  private float _speed = 2f;
   
    
       
        
        
    

    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
        _rotation = new Vector3(_horizontalMovement, 0f, _verticalMovement);
        _rotation.Normalize();
        _rotation *= _speed;
        
        
        
        
          
    }
    
}
