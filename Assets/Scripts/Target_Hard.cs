using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class Target_Hard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Player_Collect>() !=null) 
        {
            Destroy(gameObject);
        }
        
    }
}