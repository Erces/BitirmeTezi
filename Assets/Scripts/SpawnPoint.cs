using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Transform parentGrid;
    public int openingDirection;
    int rand;
    float random;
    public bool spawned = false;
    public bool canSpawnMid = true;
    public enum spawnerStyle { small, mid, large }
    public spawnerStyle gridSize;

    public GameObject spawnedGrid;

    public BoxCollider col;
    public GameObject way;
    private void Awake()
    {
        col = GetComponent<BoxCollider>();

    }
    void Start()
    {
        col = GetComponent<BoxCollider>();
        parentGrid = transform.parent;
        random = Random.Range(.02f, .07f);


        Invoke("Spawn", random);


    }
    public void IfCloseGates()
    {
        if (GridTemplates.i.totalSpawnedGrids >= GridTemplates.i.spawnGridCount)
        {
            way.SetActive(false);
        }
    }
    public void Spawn()
    {
        if (spawned)
            return;

        if (canSpawnMid)
        {

            if (openingDirection == 1)
            {
                if (GridTemplates.i.totalSpawnedGrids >= GridTemplates.i.spawnGridCount)
                {
                   // way.SetActive(false);


                }
                else if(GridTemplates.i.totalSpawnedGrids + 3 >= GridTemplates.i.spawnGridCount)
                {
                    spawnedGrid = Instantiate(GridTemplates.i.playerBase, transform.position, transform.rotation);
                    GridTemplates.i.playerBases.Add(spawnedGrid);
                }
                else
                {
                    rand = Random.Range(0, GridTemplates.i.backRooms.Count);
                    spawnedGrid = Instantiate(GridTemplates.i.backRooms[rand], transform.position , transform.rotation);
                }

            }
            else if (openingDirection == 2)
            {


                if (GridTemplates.i.totalSpawnedGrids >= GridTemplates.i.spawnGridCount)
                {
                    way.SetActive(false);

                }
                else
                {
                    rand = Random.Range(0, GridTemplates.i.backRooms.Count);
                    spawnedGrid = Instantiate(GridTemplates.i.backRooms[rand], transform.position + transform.forward * 4, transform.rotation);
                }
            }
            else if (openingDirection == 3)
            {

                if (GridTemplates.i.totalSpawnedGrids >= GridTemplates.i.spawnGridCount)
                {
                    way.SetActive(false);

                }
                else
                {
                    rand = Random.Range(0, GridTemplates.i.backRooms.Count);
                    spawnedGrid = Instantiate(GridTemplates.i.backRooms[rand], transform.position + transform.forward * 4, transform.rotation);
                }
            }
            else if (openingDirection == 4)
            {


                if (GridTemplates.i.totalSpawnedGrids >= GridTemplates.i.spawnGridCount)
                {
                    way.SetActive(false);

                }
                else
                {
                    rand = Random.Range(0, GridTemplates.i.backRooms.Count);
                    spawnedGrid = Instantiate(GridTemplates.i.backRooms[rand], transform.position + transform.forward * 4, transform.rotation);
                }
            }
            else if (openingDirection == 5)
            {


                if (GridTemplates.i.totalSpawnedGrids >= GridTemplates.i.spawnGridCount)
                {
                    way.SetActive(false);

                }
                else
                {
                    rand = Random.Range(0, GridTemplates.i.backRooms.Count);
                    spawnedGrid = Instantiate(GridTemplates.i.backRooms[rand], transform.position, transform.rotation);
                }
            }
        }
        else if (!canSpawnMid)
        {
            if (openingDirection == 1)
            {
                rand = Random.Range(0, GridTemplates.i.backRooms.Count);
                spawnedGrid = Instantiate(GridTemplates.i.backRooms[rand], transform.position, transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, GridTemplates.i.backRooms.Count);
                spawnedGrid = Instantiate(GridTemplates.i.backRooms[rand], transform.position, transform.localRotation);
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, GridTemplates.i.backRooms.Count);
                spawnedGrid = Instantiate(GridTemplates.i.backRooms[rand], transform.position, transform.localRotation);
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, GridTemplates.i.backRooms.Count);
                spawnedGrid = Instantiate(GridTemplates.i.backRooms[rand], transform.position, transform.localRotation);
            }
            else if (openingDirection == 5)
            {
                rand = Random.Range(0, GridTemplates.i.backRooms.Count);
                spawnedGrid = Instantiate(GridTemplates.i.backRooms[rand], transform.position, transform.localRotation);
            }
        }



        spawned = true;
        GridTemplates.i.totalSpawnedGrids++;
    }
    public void NothingSpawned()
    {
        //way.SetActive(false);
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint") && canSpawnMid)
        {
            if (!spawned)
            {
                NothingSpawned();

            }


            canSpawnMid = false;
            col.size = new Vector3(.5f, .5f, .5f);
            Destroy(gameObject);



        }
        else if (other.CompareTag("SpawnPoint") && !canSpawnMid)
        {

            //NothingSpawned();
             if (spawned)
            spawnedGrid.SetActive(false);
        }
    }
}
