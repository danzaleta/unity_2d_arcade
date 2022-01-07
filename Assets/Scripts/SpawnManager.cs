using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pipePrefab;
    private GameObject new_pipePrefab;

    public GameManager _gameManager;

    private float f_Timer = 0;
    
    public float f_MaxTimer = 5;
    public float f_HeightRange;

    private void Awake()
    {
        this.gameObject.transform.position = new Vector3(0,0,0);
    }

    // Start is called before the first frame update
    void Start()
    {
        new_pipePrefab = Instantiate(pipePrefab);
        new_pipePrefab.GetComponent<PipeMovement>()._gameManager = this._gameManager;
        new_pipePrefab.transform.position = transform.position + new Vector3(12, Random.Range(-f_HeightRange, f_HeightRange), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (new_pipePrefab.transform.position.x <=  4f)
        {
            //Destroy(new_pipePrefab);
            new_pipePrefab = Instantiate(pipePrefab);
            new_pipePrefab.GetComponent<PipeMovement>()._gameManager = this._gameManager;
            new_pipePrefab.transform.position = transform.position + new Vector3(12, Random.Range(-f_HeightRange, f_HeightRange), 0);
            f_Timer = 0;
        }

        f_Timer += Time.deltaTime;
    }
}
