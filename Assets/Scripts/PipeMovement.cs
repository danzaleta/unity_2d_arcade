using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    
    public float f_Speed = 5.0f;
    public GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * f_Speed * Time.deltaTime;    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("SCOOOOOOOORREEEE");
        if (collision.gameObject.tag == "Player")
        {
            _gameManager.AddScore();
        }
    }
}
