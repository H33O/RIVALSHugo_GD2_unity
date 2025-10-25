using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIControler : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        UpdateScore(0);
    }

    private void OnEnable()
    {
        Player_Collect.onTargetCollected += UpdateScore;
    }

    private void OnDisable()
    {
        Player_Collect.onTargetCollected -= UpdateScore;
    }

    public void UpdateScore(int newscore)
    {
        _scoreText.text = $"Score : {newscore.ToString()}";
        if (newscore > 50)
        { 
            _scoreText.color = Color.red;
        }
    }
}