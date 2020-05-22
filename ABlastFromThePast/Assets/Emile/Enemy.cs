using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    int currentHealth;
    public GameObject RandomDrop;
    /// <summary>
    /// /////////////////// public MonsterType mT;
    /// /////////////////// public QueteGoal qG;
    /// </summary>

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
    
    }
    void Die()
    {

        Destroy(host);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;


        ///////////////////////////////////// if (qg.goalType==GoalType.Kill){
        ///if (qg.mT== mT){
        ///qG.currentAmount++;
        ///}}



        Destroy(gameObject);
        if (RandomDrop)
        {
            Instantiate(RandomDrop, transform.position, transform.rotation);
        }
    }

}
