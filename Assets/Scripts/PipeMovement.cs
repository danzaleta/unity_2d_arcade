using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    
    public float _Speed = 5.0f;

    public LayerMask _HitMask;
    private ParticleSystem _particleSystem;
    private SpriteRenderer _spriteRenderer; 
    private AudioSource _audioSource;

    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();   
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Debug.DrawRay(new Vector2(this.transform.position.x, this.transform.position.y - 0.5f), Vector2.left * 5.5f, Color.red);
        
        if (Physics2D.Raycast( new Vector2(this.transform.position.x, this.transform.position.y - 0.5f), Vector2.left, 5.5f, _HitMask))
        {
            _particleSystem.Play();
        }

        if (transform.position.x <= -12)
        {
            Destroy(gameObject);
        }

        transform.position += Vector3.left * _Speed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _audioSource.Play();
            GameManager._GameManagerInstance.AddScore();
            _spriteRenderer.enabled = false;
        }
    }
}
