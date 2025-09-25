using System;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
   [SerializeField] private GameObject _player;

   private void Update()
   {
      transform.position = _player.transform.position;
   }
}
