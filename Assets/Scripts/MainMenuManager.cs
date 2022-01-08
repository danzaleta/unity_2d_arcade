using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Button methods

    public void PlayFlappyBird()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {   
        // Only works with editor mode
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit(); 
    }
}
