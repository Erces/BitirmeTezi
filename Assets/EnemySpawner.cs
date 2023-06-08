using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject enemy;
    public GameObject enemyFast;

    public GameObject enemyTank;

    public GameObject spawnedEnemy;
    public List<GameObject> enemies;

    public static EnemySpawner i;
    public float spawnRate;
    void Start()
    {
        i = this; 
        InvokeRepeating("SpawnEnemies", 5f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemies();
    }
    public void SpawnEnemies()
    {
        float random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                spawnedEnemy = Instantiate(enemy, spawner.transform.position + Vector3.up, spawner.transform.rotation);
                enemies.Add(spawnedEnemy);
                break;
            case 1:
                spawnedEnemy = Instantiate(enemyFast, spawner.transform.position + Vector3.up, spawner.transform.rotation);
                enemies.Add(spawnedEnemy);
                break;
            case 2:
                spawnedEnemy = Instantiate(enemyTank, spawner.transform.position + Vector3.up, spawner.transform.rotation);
                enemies.Add(spawnedEnemy);
                break;
            default:
                break;
        }
        
    }
    public void MoveEnemies()
    {
        
    }
}
