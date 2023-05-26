using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image image;

    private void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }
    public void SetHealth(float health)
    {
        health = health / 100;
        image.fillAmount = health;
    }
}
