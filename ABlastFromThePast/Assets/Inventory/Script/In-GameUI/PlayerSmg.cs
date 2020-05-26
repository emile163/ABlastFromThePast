using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmg : MonoBehaviour
{
    public float MaxHealth = 100f;

    public float armureMax = 100f;

    private static float currentHealth = 100f;

    private static float currentArmure = 100f;

    private HealthBar hb;

    private GameObject Healthbar;

    private armurebar ab;

    private GameObject ArmureBar;

    private GameObject GameOverPanel;

    private float extraHealing = 0;

    public GameObject bloodanim;

    public Transform pos;

    void Start()
    {
        GameOverPanel = GameObject.Find("GameOverUI");
        ArmureBar = GameObject.Find("fillArmure");
        ab = ArmureBar.GetComponent<armurebar>();
        Healthbar = GameObject.Find("fillhealth");
        hb = Healthbar.GetComponent<HealthBar>();
        hb.SetMaxHealth(MaxHealth, currentHealth);
        ab.SetMaxArmure(armureMax, currentArmure);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.T))
		{
            takedmg(79f);
		}

        if (Input.GetKeyDown(KeyCode.R))
        {
            Heal(30f);
        }

        if (currentArmure < 0)
		{
            currentArmure = 0;
		}

        if(currentHealth <= 0)
		{
            GameOverPanel.SetActive(true);
            Destroy(gameObject);
		}
        
    }

    public void takedmg (float dmg)
	{
        Instantiate(bloodanim, pos.position, pos.rotation);
        if (currentArmure < dmg)
        {
            dmg = dmg - currentArmure;
            currentArmure = 0;
            currentHealth -= dmg;
            hb.SetHealth(currentHealth);
            ab.SetArmure(currentArmure);
        }
        else if (currentArmure <= 0)
		{
            currentHealth -= dmg;
            hb.SetHealth(currentHealth);
        }
         if(currentArmure >= dmg)
		{
            currentArmure -= dmg;
            ab.SetArmure(currentArmure);
		}
    }

    public void Heal(float healing)
	{
       if(currentArmure < armureMax && currentHealth == MaxHealth)
		{
            currentArmure += healing;
            ab.SetArmure(currentArmure);
            if (currentArmure > armureMax)
            {
                currentArmure = armureMax;
                ab.SetArmure(currentArmure);
            }
        }
       
       if(currentHealth < MaxHealth)
		{ 
            currentHealth += healing;
            hb.SetHealth(currentHealth);
            if (currentHealth > MaxHealth)
			{
                extraHealing = currentHealth - MaxHealth;
                currentHealth = MaxHealth;
                hb.SetHealth(currentHealth);
            }

            if(currentArmure < armureMax)
			{
                currentArmure += extraHealing;
                ab.SetArmure(currentArmure);
                extraHealing = 0;
                if(currentArmure > armureMax)
				{
                    currentArmure = armureMax;
                    ab.SetArmure(currentArmure);
                }
			}
		}

    }
}
