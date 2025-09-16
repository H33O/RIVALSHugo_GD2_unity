using Unity.VisualScripting;
using UnityEngine;

public class Player_Collect : MonoBehaviour
{
    [SerializeField] private Score_DataZ _scoreDataZ;
    public void UpdateScore (int value)
    {
        _scoreDataZ.ScoreValue += value;
        
    }
    
}