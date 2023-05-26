using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GridTemplates : MonoBehaviour
{
     public int totalSpawnedGrids = 0;
    public bool fixedGridSpawn;
    [Header("IF FIXED CHANGE THIS")]
    public int spawnGridCount;
    [Header("IF RANDOM COUNT")]
    public int minSpawnGridCount;
    public int maxSpawnGridCount;
    public GameObject playerBase;
    public int deathCount = 0;
    public List<GameObject> backRooms;
    public List<GameObject> deadEndRooms;
    public List<GameObject> playerBases;
   


    public static GridTemplates i;



    private void Awake()
    {
        i = this;
        if(!fixedGridSpawn)
        spawnGridCount = Random.Range(minSpawnGridCount, maxSpawnGridCount);
    }
    private void Start()
    {
        Invoke("Check3Bases", 5.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(deathCount >= 3)
        {
            Time.timeScale = 0f;
        }
    }
    public void Check3Bases()
    {
        if(playerBases.Count< 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        foreach (var item in playerBases)
        {
            if (item.active == false)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
    }
}
