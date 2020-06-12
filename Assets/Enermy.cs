using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enermy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float health;
    public float startHeath=100;
    public int value = 30;
    public GameObject enermyDeathEffect;
    public Image heathBar;
    private bool isDead;
    private void Start()
    {
        speed = startSpeed;
        health = startHeath;
        isDead = false;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        heathBar.fillAmount = health /startHeath;
        if (health<=0 && isDead==false)
        {
            Die();
        }
    }
    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }
    void Die()
    {
        isDead = true;
        PlayerStats.money += value;
        GameObject deathEffect = Instantiate(enermyDeathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffect, 3f);
        WaveSpawn.enermiesAlive--;
        Destroy(gameObject);
    }
   
}
