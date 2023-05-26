using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Skills : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] turrets;
    public bool canUseSlow;
    public float slowCooldown;
    public bool canUseTurretUpgrade;
    public float turretUpgradeCooldown;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slowCooldown -= Time.deltaTime;
        turretUpgradeCooldown -= Time.deltaTime;
        if(slowCooldown <= 0)
        {
            slowCooldown = 0;
            canUseSlow = true;
        }
        if (turretUpgradeCooldown <= 0)
        {
            turretUpgradeCooldown = 0;
            canUseTurretUpgrade = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && canUseSlow && GameManager.i.CanBuy(50))
        {
            slowCooldown = 8;
            canUseSlow = false;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<NavMeshAgent>().speed = 0;
            }
            Invoke("ResetSpeedsEnemy", 3f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && canUseTurretUpgrade && GameManager.i.CanBuy(50))
        {
            turretUpgradeCooldown = 8;
            canUseTurretUpgrade = false;
            turrets = GameObject.FindGameObjectsWithTag("Turret");
            for (int i = 0; i < turrets.Length; i++)
            {
                turrets[i].GetComponent<Turret>().normalFireRate = 1;
            }
            Invoke("ResetSpeedsTurret", 3f);
        }
    }
    public void ResetSpeedsEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().SetSpeedNormal();
        }
    }
    public void ResetSpeedsTurret()
    {
        turrets = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < turrets.Length; i++)
        {
            turrets[i].GetComponent<Turret>().fireRate = 3;
        }
    }
}
