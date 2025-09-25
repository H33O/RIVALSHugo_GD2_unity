using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Stock_Transform : MonoBehaviour
{
    [SerializeField] static GameObject Stockage_Transform;
    private void OnTriggerEnter(Collider other)
    {
        transform.position = Stockage_Transform.transform.position;
    }

    private void Update()
    {
        Debug.Log(Stockage_Transform.ToString());
    }
}

   
   
  
