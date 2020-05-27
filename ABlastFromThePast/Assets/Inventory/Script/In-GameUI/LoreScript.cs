using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreScript : MonoBehaviour
{
	public GameObject Chart;

    void OnTriggerEnter2D(Collider2D other)
	{
		
			Chart.SetActive(true);
	}
}
