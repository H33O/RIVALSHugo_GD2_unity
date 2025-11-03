using UnityEngine;
using System.Collections.Generic;

public class AntiVirusZone : MonoBehaviour
{
    private HashSet<GameObject> destroyedViruses = new HashSet<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Virus") && !destroyedViruses.Contains(other.gameObject))
        {
            destroyedViruses.Add(other.gameObject);
            Debug.Log("Virus détruit : " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }

    private void OnEnable()
    {
        destroyedViruses.Clear();
    }
}