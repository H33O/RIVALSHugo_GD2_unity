using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    [Header("Victory Settings")]
    [SerializeField] private int _scoreToWin = 50;
    [SerializeField] private GameObject _victoryCanvas;
    [SerializeField] private string _nextSceneName = "Map_2";

    private bool _hasWon = false;

    private void OnEnable()
    {
        Player_Collect.onTargetCollected += OnScoreChanged;
    }

    private void OnDisable()
    {
        Player_Collect.onTargetCollected -= OnScoreChanged;
    }

    private void Start()
    {
        if (_victoryCanvas != null)
        {
            _victoryCanvas.SetActive(false);
        }
    }

    private void OnScoreChanged(int currentScore)
    {
        if (!_hasWon && currentScore >= _scoreToWin)
        {
            ShowVictory();
        }
    }

    private void Update()
    {
        if (_hasWon && Input.GetKeyDown(KeyCode.Return))
        {
            LoadNextLevel();
        }
    }

    private void ShowVictory()
    {
        _hasWon = true;
        
        if (_victoryCanvas != null)
        {
            _victoryCanvas.SetActive(true);
        }
        
        
        Debug.Log("Victoire ! Appuyez sur Enter pour continuer.");
    }

    private void LoadNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_nextSceneName);
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}