using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdPlayerController : MonoBehaviour
{  
    [SerializeField]
    private float _speed = 3.2f;

    private bool _isPlaying;
    private Rigidbody2D rb;
    private Animator _animator;
    private AudioSource _hitSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        _animator = GetComponent<Animator>();
        _hitSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        _isPlaying = true;
    }

    void Update()
    {   
        /*
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
        */
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * _speed;
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            if (rb.gravityScale != 1)
            {
                rb.gravityScale = 1;
            }
            Jump();
        }
    }

    public void OnPause(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            GameManager._GameManagerInstance.Pause();    
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Game over condition
        if (collision.gameObject.tag == "GameOver" && _isPlaying)
        {
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            _isPlaying = false;
            _animator.SetTrigger("BirdDeath"); // Change the animation state
            _hitSound.Play(); 
            
            GameManager._GameManagerInstance.GameOver();
        }
    }
}
