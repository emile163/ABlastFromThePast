using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmg : MonoBehaviour
{
    public float MaxHealth = 100f;

    public float armureMax = 100f;

    private float currentHealth;

    private float currentArmure;

    public HealthBar hb;

    public armurebar ab;

    void Start()
    {
        currentArmure = armureMax;
        currentHealth = MaxHealth;
        hb.SetMaxHealth(MaxHealth);
        ab.SetMaxArmure(armureMax);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
            takedmg(20);
		}
        if (Input.GetKeyDown(KeyCode.R))
        {
            takedmgArmure(20);
        }
    }

    void takedmg (int dmg)
	{
        currentHealth -= dmg;

        hb.SetHealth(currentHealth);

    }

    void takedmgArmure(int dmg)
    {
        currentArmure -= dmg;

        ab.SetArmure(currentArmure);

    }
}
