using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pipePrefab;
    private GameObject new_pipePrefab;

    private float _Timer = 0;
    
    public float _MaxTimer = 5;
    public float _HeightRange;

     void Awake()
    {
        this.gameObject.transform.position = new Vector3(0,0,0);
    }

    void Start()
    {
        // Spawns initial pipe
        SpawnPipes();   
    }

    void Update()
    {
        if (new_pipePrefab.transform.position.x <=  4f)
        {
            SpawnPipes();
            _Timer = 0;
        }

        _Timer += Time.deltaTime;
    }
    
    private void SpawnPipes()
    {
        new_pipePrefab = Instantiate(pipePrefab);
        new_pipePrefab.transform.position = transform.position + new Vector3(12, Random.Range(-_HeightRange, _HeightRange), 0);
    }
}
