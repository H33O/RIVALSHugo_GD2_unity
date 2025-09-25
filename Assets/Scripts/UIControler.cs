using TMPro;
using UnityEngine;

public class UIControler : MonoBehaviour
{
   [SerializeField] private TMP_Text _scoreText;

   private void Start()
   {
       UpdateScore(0);
   }
       
           
   public void UpdateScore(int newscore)
   {
       _scoreText.text = $"Score : {newscore.ToString()}";
   }
}
