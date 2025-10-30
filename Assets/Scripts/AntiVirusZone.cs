using UnityEngine;

public class AntiVirusZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Virus"))
        {
            Debug.Log("Virus détruit : " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Virus"))
        {
            Debug.Log("Virus détruit : " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}