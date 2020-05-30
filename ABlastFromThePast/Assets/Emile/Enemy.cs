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
    public float currentHealth;

    public movingennemy me;
    private Inventory inventory;
    private GameObject inv;
    private GameObject pickUpText;
    private GameObject FullInventoryText;
    public GameObject[] RandomDrop;
    public int numberOfDrop = 1;
    private Vector3 dorp;

    /// <summary>
    /// /////////////////// public MonsterType mT;
    /// /////////////////// public QueteGoal qG;
    /// </summary>

    public GameObject bloodanim;

    void Start()
    {
        
        player = FindObjectOfType<PlayerControllerclem>();

        currentHealth = maxHealth;

        inv = GameObject.Find("Inventory");
        inventory = inv.GetComponent<Inventory>();

    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(bloodanim != null)
            Instantiate(bloodanim, transform.position, transform.rotation);

        if (currentHealth <= 0) {
            inv.SetActive(true);
            Die();
        }
    
    }
    void Die()
    {
        int verif = 0;
        for (int i = 0; i < player.listeQuete.Count; i++)
        {
            if (player.listeQuete[i].qG.Equals(GoalType.Kill)) { 
            Debug.Log("type de monstre tué :" + this.typeDeMonstre + "type de monstre attendu :" + player.listeQuete[i].qG.mT);
            if (player.listeQuete[i].isActive && player.listeQuete[i].qG.mT.Equals(this.typeDeMonstre))
            {

                Debug.Log((player.listeQuete[i].isActive && player.listeQuete[i].qG.Equals(this.typeDeMonstre)).ToString());
                player.incrementeGoal(i);
            }
        }
        }
        Destroy(gameObject);
        if(me!=null)
           me.destroy();
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

                Instantiate(RandomDrop[UnityEngine.Random.Range(0, RandomDrop.Length)], dorp, transform.rotation);
            }
        }
    }


}


public enum TypeDeMonstre
{
    None,
    Vache,
    Ours,
    Clement,
    Mémille
        



}
