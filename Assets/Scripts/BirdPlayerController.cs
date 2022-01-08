using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPlayerController : MonoBehaviour
{  
    // PUBLIC
    public float _speed = 3.2f;

    // PRIVATE
    private bool _isPlaying;
    private Rigidbody2D rb;
    private Animator _animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _isPlaying = true;
    }

    void Update()
    {
        if (_isPlaying)
        {
            // Jump action
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (rb.gravityScale != 1)
                {
                    rb.gravityScale = 1;
                }
                Jump();
            }

            // Pause action
            if (Input.GetKeyDown(KeyCode.P))
            {
                GameManager._GameManagerInstance.Pause();
            }
        }
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Game over condition
        if (collision.gameObject.tag == "GameOver" && _isPlaying)
        {
            _isPlaying = false;
            _animator.SetTrigger("BirdDeath"); // Change the animation state
            this.gameObject.GetComponent<AudioSource>().Play(); 
            
            GameManager._GameManagerInstance.GameOver();
        }
    }
}
