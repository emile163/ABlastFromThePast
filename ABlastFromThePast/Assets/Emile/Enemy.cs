using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    int currentHealth;
    public GameObject RandomDrop;
    public movingennemy me;
    private Inventory inventory;
    private GameObject inv;
    private GameObject pickUpText;
    private GameObject FullInventoryText;
    /// <summary>
    /// /////////////////// public MonsterType mT;
    /// /////////////////// public QueteGoal qG;
    /// </summary>

    public GameObject bloodanim;

    void Start()
    {
        currentHealth = maxHealth;

        inv = GameObject.Find("Inventory");
        inventory = inv.GetComponent<Inventory>();

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Instantiate(bloodanim, transform.position, transform.rotation);

        if (currentHealth <= 0) {
            inv.SetActive(true);
            Die();
        }
    
    }
    void Die()
    {
        ///////////////////////////////////// if (qg.goalType==GoalType.Kill){
        ///if (qg.mT== mT){
        ///qG.currentAmount++;
        ///}}
        Destroy(gameObject);
        me.destroy();
        if (RandomDrop)
        {
            Instantiate(RandomDrop, transform.position, transform.rotation);
            
        }
    }

}
