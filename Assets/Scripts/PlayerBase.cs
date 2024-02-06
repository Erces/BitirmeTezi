using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public float HP;
    public float MaxHP;
    public HealthBar healthBar;
    public int currentEnemyOnTheWay;
    public int killedEnemy;
    public float enemyAICost;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("TakeDamage");
       
        HP -= damage;
        healthBar.SetHealth(HP);
        if (HP < 0)
        {
            Die();
        }
        
    }
    public void Die()
    {
        GridTemplates.i.playerBases.Remove(this.gameObject);
        GridTemplates.i.deathCount++;
        Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //GameManager.i.DoTweenCamShake(99, 99, 55);
            var damage = other.GetComponent<Enemy>().enemyPower;
            HP -= damage * Time.deltaTime;
            healthBar.SetHealth(HP);
            if (HP < 0)
            {
                Die();
            }
        }
    }
}
