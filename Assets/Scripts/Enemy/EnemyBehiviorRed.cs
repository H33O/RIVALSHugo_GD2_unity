using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviorRed : MonoBehaviour
{
    [SerializeField] private int _targetValue = 1;
    private bool hasCollided = false;

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
                other.gameObject.GetComponent<Player_Collect>().UpdateScore(-1);
            }
        }
        else if (other.CompareTag("Red"))
        {
            Debug.Log("Red");
            if (other.gameObject.GetComponent<Player_Collect>() != null)
            {
                hasCollided = true;
                other.gameObject.GetComponent<Player_Collect>().UpdateScore(1);
                Destroy(gameObject);
            }
               
            
        }
    }
}