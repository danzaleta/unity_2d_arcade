using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager _GameManagerInstance { get; private set; }
    private int i_Score;

    public GameObject _player;
    public GameObject _pipeManager;
    public Canvas _gameOverCanvas;
    public TextMeshProUGUI _scoreText;

    private void Awake()
    {
         if (_GameManagerInstance == null)
        {
            _GameManagerInstance = this;
        }
        //DontDestroyOnLoad(this.gameObject);
        
        this.gameObject.transform.position = new Vector3(0, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        _gameOverCanvas.GetComponent<Canvas>().enabled = false;

        _player = Instantiate(_player);
        _player.GetComponent<BirdPlayerController>().gameManager = this; 
        _player.transform.position = new Vector3(-5, 0, 0);

        Debug.Log("Player spawned");  
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameOverCanvas.GetComponent<Canvas>().enabled)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Restart();
            }
        }
    }

    public void AddScore()
    {
        i_Score++;
        _scoreText.text = i_Score.ToString();
    }

    // Game Over methods

    public void GameOver()
    {
        Time.timeScale = 0;
        ShowGameOverScreen();
    }

    private void ShowGameOverScreen()
    {
        if (_gameOverCanvas != null)
        {
            _gameOverCanvas.GetComponent<Canvas>().enabled = true;
            ShowGameResults();  
        }
    }

    private void ShowGameResults()
    {
       
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
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}
