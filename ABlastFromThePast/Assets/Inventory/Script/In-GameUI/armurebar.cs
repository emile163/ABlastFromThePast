using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class armurebar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxArmure(float Armure)
	{
		slider.maxValue = Armure;
		slider.value = Armure;
	}

	public void SetArmure(float Armure)
	{
		slider.value = Armure;
	}
}
