using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float baseSpeed;
    public int maxhp = 25;
    public int newhp;
    public float maxspeed = 4f;
    public float newspeed;
    public float removeSpeed = 5f;
    public Boolean slowed = false;
    public Boolean lasered = false;
    public NavMeshAgent agent;
    public Transform test;
    public float enemyPower = 5f;
    public HealthBar healthBar;
    public GameObject lockedObject;
    public List<GameObject> playerBaseList;
    float minPathCost;
    int minPathNumber;
    int counter = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        newhp = maxhp;
        newspeed = maxspeed;
        ThinkForDestination();
        InvokeRepeating("CheckForTowers", 0, 1);
        if(GameManager.i.gameTime > 90)
        {
            newhp *= 2;
            newspeed *= 2;
            enemyPower *= 2;
        }

    }
    public void SetSpeedNormal()
    {
        agent.speed = baseSpeed;
    }
    public void ThinkForDestination()
    {
        counter = 0;
        minPathNumber = 0;
        
        playerBaseList = GridTemplates.i.playerBases;
      
  
        foreach (var item in playerBaseList)
        {
            PlayerBase playerBase = item.GetComponent<PlayerBase>();
            agent.SetDestination(item.transform.position);
            float pathLength = agent.remainingDistance;
            Debug.Log(pathLength);
            var cost = (playerBase.killedEnemy + playerBase.currentEnemyOnTheWay+1) * pathLength;
            Debug.Log(cost);
           
            
            if(cost < minPathCost)
            {
                minPathNumber = counter;
            }
            counter++;
        }
        agent.SetDestination(GridTemplates.i.playerBases[minPathNumber].transform.position);
        GridTemplates.i.playerBases[minPathNumber].GetComponent<PlayerBase>().currentEnemyOnTheWay++;
        lockedObject = GridTemplates.i.playerBases[minPathNumber];

    }
    public void losespeed(float slow)
    {
        if (slowed == false)
        {
            newspeed = newspeed / slow;
            agent.speed = newspeed;
            //Debug.Log("losespeed"+newspeed);
            slowed = true;
            Invoke("removeSlow", removeSpeed); 
        }
        
    }

        void removeSlow()
    {
        newspeed = maxspeed;
        agent.speed = newspeed;
       // Debug.Log("removeslow"+newspeed);
        slowed = false;
    }

    public void losehp(int damage) 
    {
        newhp = newhp - damage;

        healthBar.SetHealth(newhp);
        Debug.Log(newhp);
        if (newhp <= 0)
        {
            if(lockedObject.GetComponent<PlayerBase>() != null)
            {
                lockedObject.GetComponent<PlayerBase>().killedEnemy++;
            }
            EnemySpawner.i.enemies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
    public void CheckForTowers()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 6);
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.tag == "Tower")
            {
                Debug.Log("Tower Found!");
                lockedObject = hitCollider.gameObject;
                agent.SetDestination(lockedObject.transform.position);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(lockedObject == null)
        {
            ThinkForDestination();
        }
    }
    //transform.Translate(Vector3.left * newspeed * Time.deltaTime);



}
