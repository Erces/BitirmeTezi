using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    public float HP;
    public float MaxHP;
    public HealthBar healthBar;
    public int price;
    public float time;
    void Start()
    {
        time = 15;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time<= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        GameManager.i.DoTweenCamShake(9, 9, 55);
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
        Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
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
