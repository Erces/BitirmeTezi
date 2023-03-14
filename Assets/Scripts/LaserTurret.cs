using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    //targeting
    public Transform target;
    public float range = 15f;
    public Transform rotatePart;
    public int bulletLimit = 2;
    //shooting
    public float fireRate = 2f;
    public Transform bulletPart;
    public Transform fireLocation;
    

    void Start()
    {
        InvokeRepeating("ChangeTarget", 0f, 0.5f);
        //InvokeRepeating("ShootBullet", 0f, fireRate);
    }

    void ChangeTarget()
    {
        GameObject[] laserList = GameObject.FindGameObjectsWithTag("Laser");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            GameObject enemyobj = enemy.gameObject;
            Enemy enemyscript = enemyobj.GetComponent<Enemy>();

            if (distance < shortestDistance && enemyscript.lasered==false)
            { shortestDistance = distance;
                nearestEnemy = enemy;
                
            }
        }
       
        if(nearestEnemy != null && shortestDistance < range && laserList.Length<bulletLimit)
        {
            target = nearestEnemy.transform;
            //Debug.Log("laser shoot");
            ShootBullet();

        }
        else { target = null; }
    }

    void ShootBullet()
    {
        if(target != null) {
            GameObject newLaser = Instantiate(bulletPart, fireLocation.position, fireLocation.rotation).gameObject;
            //GameObject newBullet = GameObject.Find("Bullet(Clone)");
            Laser laser = newLaser.GetComponent<Laser>();

            if (laser != null)
                laser.Seek(target,this.transform);
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotatation = lookRotation.eulerAngles;
        rotatePart.rotation = Quaternion.Euler(0f,rotatation.y,0f);


    }
}
