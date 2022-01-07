using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPlayerController : MonoBehaviour
{
    public float f_Speed = 5;
    private Rigidbody2D rb;

    public GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.gravityScale != 1)
            {
                rb.gravityScale = 1;
            }

            // Jump
            //Debug.Log("Fly little bird");
            rb.velocity = Vector2.up * f_Speed;
        }

        if (Input.GetKeyDown(KeyCode.P))
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GameOver")
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            gameManager.GameOver();
        }
    }
}
