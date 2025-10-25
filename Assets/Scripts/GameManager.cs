using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScoreDatas _scoreData;
    [SerializeField] private UIControler _uiControler;

    private void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        _scoreData.ResetScore();
        _uiControler.UpdateScore(0);
    }
}