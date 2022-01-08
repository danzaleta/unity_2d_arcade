using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    // PUBLIC
    public static GameInstance _GameInstance;
    public int _FPS = 60;

    void Awake()
    {
        // Singleton pattern
        if (_GameInstance == null)
        {
            _GameInstance = this;

            SetFrameRate(_FPS);
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        this.gameObject.transform.position = new Vector3(0, 0, 0);
    }

    // Locks the app framerate
    private void SetFrameRate(int fps)
    {
        Application.targetFrameRate = fps;
    }

}
