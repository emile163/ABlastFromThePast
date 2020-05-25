using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class armurebar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxArmure(float MaxArmure, float currentArmure)
	{
		slider.maxValue = MaxArmure;
		slider.value = currentArmure;
	}

	public void SetArmure(float Armure)
	{
		slider.value = Armure;
	}
}
