using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerControllerclem player;
    public TypeDeMonstre typeDeMonstre;
    public int maxHealth = 100;
    public int currentHealth;

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
        player = FindObjectOfType<PlayerControllerclem>();

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
        int verif = 0;
        for (int i = 0; i < player.listeQuete.Count; i++)
        {
            if (player.listeQuete[i].qG.Equals(GoalType.Kill)) { 
            Debug.Log("type de monstre tué :" + this.typeDeMonstre + "type de monstre attendu :" + player.listeQuete[i].qG.mT);
            if (player.listeQuete[i].isActive && player.listeQuete[i].qG.mT.Equals(this.typeDeMonstre))
            {

                player.moveSpeed++;
                Debug.Log((player.listeQuete[i].isActive && player.listeQuete[i].qG.Equals(this.typeDeMonstre)).ToString());
                player.incrementeGoal(i);
            }
        }
        }
        Destroy(gameObject);
        me.destroy();
        if (RandomDrop)
        {
            Instantiate(RandomDrop, transform.position, transform.rotation);
            
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
