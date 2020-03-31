using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    int currentHealth;
    public GameObject host;
    public GameObject FXDeathPrefab;
    public GameObject RandomDrop;
    void Start()
    {
        currentHealth = maxHealth;
        
    }
    public void TakeDamage(int damage)
    {
        if (FXDeathPrefab)
        {
            GameObject fxDeath = Instantiate(FXDeathPrefab, transform.position, FXDeathPrefab.transform.rotation) as GameObject;
            Destroy(fxDeath, 3f);
        }

        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
        }
    
    }
    void Die()
    {
        Destroy(host);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;

        if (RandomDrop)
        {
            Instantiate(RandomDrop, transform.position, transform.rotation);
        }
    }
}
