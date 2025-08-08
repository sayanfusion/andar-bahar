using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void HandlePlayButton()
    {
        Debug.Log("I am clicked");
        string sceneName = "SampleScene";

        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.Log("I have Entered The Rummy Game");
            SceneManager.LoadScene(sceneName);
        }

        else
        {
            Debug.Log("SceneName is no Valid");
        }
    }
    public void HandleExitButton()
    {
        Debug.Log("I am clicked");
        string sceneName = "PlayerMainMenu";

        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.Log("Back to the MainMenu");
            SceneManager.LoadScene(sceneName);
        }

        else
        {
            Debug.Log("SceneName is no Valid");
        }
    }
     public void HandleQuitButton()
    {
        Application.Quit();
    }
}
