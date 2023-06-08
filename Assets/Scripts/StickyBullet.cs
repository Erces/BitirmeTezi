using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBullet : MonoBehaviour
{
    Enemy enemyscript;
    public Transform target;

    public float speed = 5f;

    public int damage = 1;

    public float slow = 2f;


    public void Seek(Transform _target)
    {
        target = _target;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) 
        {
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == target.gameObject && target != null)
        {
            enemyscript = target.GetComponent<Enemy>();
            enemyscript.losespeed(slow);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("TriggerSlow");
            enemyscript = target.GetComponent<Enemy>();
            enemyscript.losespeed(slow);
            Destroy(this.gameObject);
        }
    }
}