using UnityEngine;

[CreateAssetMenu(fileName = "ScoreDatas", menuName = "Scriptable Objects/ScoreDatas")]
public class ScoreDatas : ScriptableObject
{
    public int ScoreValue = 0;
    
    public void ResetScore()
    {
        ScoreValue = 0;
    }
}