using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxhp = 25;
    public int newhp;
    public float maxspeed = 4f;
    public float newspeed;
    public float removeSpeed = 5f;
    public Boolean slowed = false;
    public Boolean lasered = false;

    public float enemyPower = 5f;
    void Start()
    {
        newhp = maxhp;
        newspeed = maxspeed;

    }

    public void losespeed(float slow)
    {
        if (slowed == false)
        {
            newspeed = newspeed / slow;
            //Debug.Log("losespeed"+newspeed);
            slowed = true;
            Invoke("removeSlow", removeSpeed); 
        }
        
    }

        void removeSlow()
    {
        newspeed = maxspeed;
       // Debug.Log("removeslow"+newspeed);
        slowed = false;
    }

    public void losehp(int damage) 
    {
        newhp = newhp - damage;
        Debug.Log(newhp);
        if (newhp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * newspeed * Time.deltaTime);
      
    }
}
