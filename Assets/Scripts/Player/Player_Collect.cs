using System;
using UnityEngine;

public class Player_Collect : MonoBehaviour
{
    [SerializeField] private ScoreDatas _scoreData;
    [SerializeField] private UIControler _uiControler;
    public static Action<int> onTargetCollected;
    public void UpdateScore(int value)
    {
        _scoreData.ScoreValue = Mathf.Clamp(_scoreData.ScoreValue+ value,0,_scoreData.ScoreValue+ value);
        _uiControler .UpdateScore(_scoreData.ScoreValue);
        onTargetCollected?.Invoke(_scoreData.ScoreValue);
    }
    
}
