using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    [Header("Victory Settings")]
    [SerializeField] private int _scoreToWin = 50;
    [SerializeField] private GameObject _victoryCanvas;
    [SerializeField] private string _nextSceneName = "Map_2";
    [SerializeField] private AudioClip _VictorySound;
    private AudioSource _audioSource;
    private Scene  _scene;

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
        _victoryCanvas.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
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
        _victoryCanvas.SetActive(true);
        _audioSource.PlayOneShot(_VictorySound);
        
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