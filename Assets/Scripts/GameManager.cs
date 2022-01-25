using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager _GameManagerInstance;

    private int _Score;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _pipeManager;

    [SerializeField]
    private Canvas _gameOverCanvas;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    private void Awake()
    {
         if (_GameManagerInstance == null)
         {
            _GameManagerInstance = this; 
         }
         else
         {
            Destroy(this.gameObject);  
         }
        this.gameObject.transform.position = new Vector3(0, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        _gameOverCanvas.enabled = false;

        _player = Instantiate(_player);
        _player.transform.position = new Vector3(-5, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameOverCanvas.enabled)
        {

        }
    }

    public void Pause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void AddScore()
    {
        _Score++;
        _scoreText.text = _Score.ToString();
    }

    // Game Over methods

    public void GameOver()
    {
        Time.timeScale = 0.2f;
        ShowGameOverScreen();
    }

    private void ShowGameOverScreen()
    {
        if (_gameOverCanvas != null)
        {
            _gameOverCanvas.enabled = true;
        }
    }

    // Game Over screen button methods

    public void Restart()
    {
        if (Application.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }

    public void MainMenu()
    {
        if (Application.isPlaying)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }

    public void ExitGame()
    {
        // Only works with editor mode 
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}
