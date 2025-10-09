using Unity.VisualScripting;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public Transform positionEnnemy;
    
    

    // Update is called once per frame
    void Update()
    {
        transform.position = positionEnnemy.position;
        
    }
}
