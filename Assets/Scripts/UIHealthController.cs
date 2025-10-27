using UnityEngine;
using TMPro;

public class UIHealthController : MonoBehaviour
{
    [Header("Health UI")]
    [SerializeField] private TMP_Text _healthText;
   
    private void OnEnable()
    {
        HealthSystem.onHealthChanged += UpdateHealthDisplay;
    }

    private void OnDisable()
    {
        HealthSystem.onHealthChanged -= UpdateHealthDisplay;
    }

    private void Start()
    {
        UpdateHealthDisplay(3);
    }

    private void UpdateHealthDisplay(int currentHealth)
    {
        if (_healthText != null)
        {
            _healthText.text = $"Nombre de vie : {currentHealth}";
            
        }
    }

    

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
    
 }   
    