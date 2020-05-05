using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string level;
    // Start is called before the first frame update
   public void Play()
    {
        SceneManager.LoadScene(level);
        FindObjectOfType<AudioManager>().Play("Launching");
    }

   public void Exit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
