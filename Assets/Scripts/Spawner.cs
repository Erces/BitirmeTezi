using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float repeatRate = 7f;
    public GameObject enemy;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy() 
    {
        Instantiate(enemy,transform.position,transform.rotation);
    }
}
