using TMPro;
using UnityEngine;

public class UIControler : MonoBehaviour
{
    [SerializeField] private GameObject _loseCanvas;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private ScoreDatas _scoreData;

    private bool _hasLost = false;

    private void Start()
    {
        if (_loseCanvas != null)
        {
            _loseCanvas.SetActive(false);
        }
        
        if (_scoreData != null)
        {
            UpdateScore(_scoreData.ScoreValue);
        }
        
    }

    private void OnEnable()
    {
        Player_Collect.onTargetCollected += UpdateScore;
    }

    private void OnDisable()
    {
        Player_Collect.onTargetCollected -= UpdateScore;
    }

    public void UpdateScore(int newScore)
    {
        if (_scoreText != null)
        {
            _scoreText.text = $"Score : {newScore}";
        }
        
    }

 

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}