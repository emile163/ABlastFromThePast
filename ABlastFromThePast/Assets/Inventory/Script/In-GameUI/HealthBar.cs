using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float Maxhealth, float currentHealth)
	{
		slider.maxValue = Maxhealth;
		slider.value = currentHealth;
	}

	public void SetHealth(float health)
	{
		slider.value = health;
	}
}
