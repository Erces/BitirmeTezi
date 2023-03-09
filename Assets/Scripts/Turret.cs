using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //targeting
    public Transform target;
    public float range = 15f;
    public Transform rotatePart;
    //shooting
    public float fireRate = 2f;
    public Transform bulletPart;
    public Transform fireLocation;
    

    void Start()
    {
        InvokeRepeating("ChangeTarget", 0f, 0.5f);
        InvokeRepeating("ShootBullet", 0f, fireRate);
    }

    void ChangeTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            { shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance < range)
        {
            target = nearestEnemy.transform;
        }
        else { target = null; }
    }

    void ShootBullet()
    {
        if(target != null) {
            GameObject newBullet = Instantiate(bulletPart, fireLocation.position, fireLocation.rotation).gameObject;
            //GameObject newBullet = GameObject.Find("Bullet(Clone)");
            Bullet bullet = newBullet.GetComponent<Bullet>();

            if (bullet != null)
                bullet.Seek(target);
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
