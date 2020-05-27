using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanneauDeFact : MonoBehaviour
{
	public GameObject panneau;
	
    public void fermerPanneau()
	{
		panneau.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (Input.GetKeyDown(KeyCode.E))
			panneau.SetActive(true);
	}

}
