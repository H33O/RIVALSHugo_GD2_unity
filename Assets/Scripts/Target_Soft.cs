using System;
using System.Collections;
using UnityEngine;

public class Target_Soft : MonoBehaviour
{
    [SerializeField] private int _targetValue = 1;
    [SerializeField] private float _ShadowDuration = 3f;
    private float _ShadowTimer = 0f;
    private bool _isinShadow = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player_Collect>() != null)
        {
            other.gameObject.GetComponent<Player_Collect>().UpdateScore(_targetValue);
            //Destroy(gameObject);
            //TODO timer
            toglVisibility(false);
            StartCoroutine(_ShadowTimerControl());
        }
    }

    private void toglVisibility(bool newVisibility)
    {
        GetComponent<MeshRenderer>().enabled = newVisibility;
        GetComponent<Collider>().enabled = newVisibility;
    }
    

    /*
    private void Update()
    {
        if (_isinShadow)
        {
            _ShadowTimer += Time.deltaTime;
            if (_ShadowTimer >= _ShadowDuration)
            {     
                //TODO targer        
                toglVisibility(false
                //TODO timer
                _ShadowTimer = 0f;
            }
            
        }*/ private IEnumerator _ShadowTimerControl()
    {
        yield return new WaitForSeconds(_ShadowDuration);
        toglVisibility(true);
    }
    
    }

