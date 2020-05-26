﻿using System.Collections;
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
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            movingUp = false;
            movingDown = false;
            movingLeft = false;
            movingRight = true;
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f)
        {
            movingUp = true;
            movingDown = false;
            movingLeft = false;
            movingRight = false;
        }

        if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            movingUp = false;
            movingDown = false;
            movingLeft = true;
            movingRight = false;
        }

        if (Input.GetAxisRaw("Vertical") < -0.5f)
        {
            movingUp = false;
            movingDown = true;
            movingLeft = false;
            movingRight = false;
            Debug.Log("bas");
        }
        animator.SetBool("attack", false);


        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                attackPoint.position = pos.position;

                if (movingUp == true)
                {
                    animator.SetFloat("moveY", 1);
                    animator.SetFloat("moveX", 0);
                    attackPoint.transform.position += new Vector3(0, 0.18f, 0);
                    animator.SetBool("attack", true);
                }
                if (movingDown == true)
                {
                    animator.SetFloat("moveY", -1);
                    animator.SetFloat("moveX", 0);
                    attackPoint.transform.position += new Vector3(0, -0.18f, 0);
                    animator.SetBool("attack", true);
                }
               if (movingLeft == true)
                {
                    animator.SetFloat("moveX", -1);
                    animator.SetFloat("moveY", 0);
                    attackPoint.transform.position += new Vector3(-0.18f, 0, 0);
                    animator.SetBool("attack", true);
                }
               if (movingRight == true)
                {
                    animator.SetFloat("moveX", 1);
                    animator.SetFloat("moveY", 0);
                    attackPoint.transform.position += new Vector3(0.18f, 0, 0);
                    animator.SetBool("attack", true);
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
    /*void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange); 
        

    }*/

}
