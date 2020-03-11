using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
   
    public Transform attackPoint;
    
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public Transform pos;
    bool movingRight ;
    bool movingLeft;
    bool movingUp ;
    bool movingDown;
    bool moving;
    void Update()
    {


        if (moving == true)
        {
            if (Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
            {
                movingUp = false;
                movingDown = false;
            }
            if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
            {
                movingUp = false;
                movingDown = false;
            }
            if (Input.GetKey(KeyCode.W) && !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
            {
                movingRight = false;
                movingLeft = false;
            }
            if (Input.GetKey(KeyCode.S) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                movingRight = false;
                movingLeft = false;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            moving = true;
            movingUp = true;
            movingDown = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moving = true;
            movingUp = false;
            movingDown = true;
        }
        
         
        
        if (Input.GetKey(KeyCode.A))
        {
            moving = true;
            movingLeft = true;
            movingRight = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moving = true;
            movingLeft = false;
            movingRight = true;
        }
        if(!(Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)))
        {
            
            moving = false;
        }


        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
               

                    attackPoint.position = pos.position;

                 
                Debug.Log("Moving ="+moving);
                Debug.Log("MovingRight =" + movingRight);
                Debug.Log("MovingLeft =" + movingLeft);
                Debug.Log("MovingUp =" + movingUp);
                Debug.Log("MovingDown =" + movingDown);

                if (movingUp == true)
                {
                    attackPoint.transform.position += new Vector3(0, 0.18f, 0);

                }
                if (movingDown == true)
                {
                    attackPoint.transform.position += new Vector3(0, -0.18f, 0);

                }
               if (movingLeft == true)
                {
                    attackPoint.transform.position += new Vector3(-0.18f, 0, 0);

                }
               if (movingRight == true)
                {
                    attackPoint.transform.position += new Vector3(0.18f, 0, 0);

                }
               
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
               
            }
    }
    }
    void Attack()
    {
        

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        
        }
        

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange); 
        

    }

}
