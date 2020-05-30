using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreScript : MonoBehaviour
{
	public GameObject Chart;

	bool inRange = false;

	public void HideChart()
	{
		Chart.SetActive(false);
	}

    void OnTriggerEnter2D(Collider2D other)
	{
		inRange = true;
			
	}

	void OnTriggerExit2D(Collider2D other)
	{
		inRange = false;
	}
	
	void Update()
	{
		if(inRange == true)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				Chart.SetActive(true);
			}
		}
	}
}
