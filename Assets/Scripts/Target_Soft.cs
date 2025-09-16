using UnityEngine;

public class Target_Soft : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Player_Collect>() !=null) 
        {
            Destroy(gameObject);
        }
        
    }
}