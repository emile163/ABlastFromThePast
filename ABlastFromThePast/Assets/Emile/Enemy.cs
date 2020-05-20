using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    int currentHealth;
    public GameObject RandomDrop;
    public GameObject bloodanim;

    void Start()
    {
        currentHealth = maxHealth;
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Instantiate(bloodanim, transform.position, transform.rotation);

        if (currentHealth <= 0) {
            Die();
        }
        Debug.Log(currentHealth);
    
    }
    void Die()
    {
        Destroy(gameObject);
        if (RandomDrop)
        {
            Instantiate(RandomDrop, transform.position, transform.rotation);
        }
    }

}
