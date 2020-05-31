using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerControllerclem player;
    public TypeDeMonstre typeDeMonstre;
    public float maxHealth = 100f;
    private float currentHealth;

    public movingennemy me=new movingennemy();
    private static Inventory inventory;
    private  GameObject inv;
    private GameObject pickUpText;
    private GameObject FullInventoryText;
    public GameObject[] RandomDrop;
    public int numberOfDrop = 1;
    private Vector3 dorp;
    static bool unefois = true;

    /// <summary>
    /// /////////////////// public MonsterType mT;
    /// /////////////////// public QueteGoal qG;
    /// </summary>

    public GameObject bloodanim;

    void Start()
    {
		if (unefois)
		{
            inv = GameObject.Find("Inventory");
            inventory = inv.GetComponent<Inventory>();
            unefois = false;
        }
        player = FindObjectOfType<PlayerControllerclem>();
        currentHealth = maxHealth;

        

    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(bloodanim != null)
            Instantiate(bloodanim, transform.position, transform.rotation);

        if (currentHealth <= 0) {
            Die();
        }
    
    }
    void Die()
    {
        int verif = 0;
        for (int i = 0; i < player.listeQuete.Count; i++)
        {
            if (player.listeQuete[i].qG.goalType.Equals(GoalType.Kill)) 
            { 
                if (player.listeQuete[i].isActive && player.listeQuete[i].qG.mT.Equals(this.typeDeMonstre))
                {
                    player.incrementeGoal(i);
                }
            }
        }
        Destroy(gameObject);
        if(me!=null)
           me.destroy();
        if (RandomDrop != null)
        
        if (RandomDrop != null)
        {
			for (int i = 0; i < numberOfDrop; i++)
			{
                if(i == 0)
				{
                    dorp = transform.position;
				}
                if(i == 1)
				{
                    dorp = transform.position + new Vector3(0.3f, 0.3f);
                }
                if (i == 2)
                {
                    dorp = transform.position + new Vector3(-0.3f, 0.3f);
                }
                if (i == 3)
                {
                    dorp = transform.position + new Vector3(0.3f, -0.3f);
                }
                if (i == 4)
                {
                    dorp = transform.position + new Vector3(-0.3f, -0.3f);
                }
                 else
                   dorp = transform.position;
                Instantiate(RandomDrop[UnityEngine.Random.Range(0, RandomDrop.Length)], dorp, transform.rotation);
            }
        }
        try
        {
            me.destroy();
        }
        catch (Exception e) { }
    }


}


public enum TypeDeMonstre
{
    None,
    Vache,
    Ours,
    Poulet,
    renard,
    Clement,
    Mémille
        



}
