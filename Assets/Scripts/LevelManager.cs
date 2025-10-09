using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            
            Loadanewlevel(1);
        }
    }

    public void Loadanewlevel(int buildindex)
    {
        SceneManager.LoadScene(buildindex);
    }
    
    
}
