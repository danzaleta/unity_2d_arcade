using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _AudioManagerInstance;
    private AudioSource _audioSource;

    private void Awake()
    {
        // Singleton pattern
        if (_AudioManagerInstance == null)
        {
            _AudioManagerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);   
        }
        this.gameObject.transform.position = new Vector3(0, 0, 0);
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }
}
