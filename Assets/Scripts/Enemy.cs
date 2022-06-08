using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float health;

    public float startHealth = 100f;

    public Image healthBar;
    
    public int worth = 50;

    public GameObject deathEffect;
    
    
    
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;
        
        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }   
    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        
        PlayerStats.Money += worth;
        Destroy(gameObject);
    }


}