using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public static GameInstance _GameInstance;
    
    [SerializeField]
    private int _FPS = 5;

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
