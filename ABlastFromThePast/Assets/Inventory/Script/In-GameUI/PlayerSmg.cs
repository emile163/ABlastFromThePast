using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmg : MonoBehaviour
{
    public float MaxHealth = 100f;

    public float armureMax = 0;

    private static float currentHealth = 100f;

    private static float currentArmure = 0;

    private float tempArmure;

    private HealthBar hb;

    private GameObject Healthbar;

    private armurebar ab;

    private GameObject ArmureBar;

    public GameObject GameOverPanel;

    private float extraHealing = 0;

    private bool blocking = false;

    public GameObject bloodanim;

    public Transform pos;

    public GameObject shield;

    public PlayerCombat combat;

    private static bool once = true;

    public GameObject bug;

    void Start()
    {
        ArmureBar = GameObject.Find("fillArmure");
        ab = ArmureBar.GetComponent<armurebar>();
        Healthbar = GameObject.Find("fillhealth");
        hb = Healthbar.GetComponent<HealthBar>();
        if(once == true)
		{
            hb.SetMaxHealth(MaxHealth, currentHealth);
            ab.SetMaxArmure(armureMax, currentArmure);
            once = false;
        }
       

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && bug != null)
		{
            bug.SetActive(false);
		}
        if (Input.GetKeyDown(KeyCode.B))
        {
            blocking = true;
            shield.SetActive(true);
            combat.Isblockking(true);
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            blocking = false;
            shield.SetActive(false);
            combat.Isblockking(false);
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
        if (blocking == false)
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
            if (currentArmure >= dmg)
            {
                currentArmure -= dmg;
                ab.SetArmure(currentArmure);
            }
        }
    }

    public void AjouterArmure(float _armure)
	{
        tempArmure = armureMax - currentArmure;
        currentArmure = _armure - tempArmure;
        armureMax = _armure;
        ab.SetMaxArmure(_armure, currentArmure);
    }

    public void EnleverArmure(float _armure)
	{
        tempArmure = armureMax - currentArmure; //dmg done
        if (armureMax - _armure < tempArmure)
        {
            currentArmure = _armure - (tempArmure - (armureMax - _armure));
        }
        else
            currentArmure = _armure;
        armureMax = _armure;
        ab.SetMaxArmure(armureMax, currentArmure);
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
