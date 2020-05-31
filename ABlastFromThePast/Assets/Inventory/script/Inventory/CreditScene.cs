using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScene : MonoBehaviour
{
	public GameObject fini;

    void OnTriggerEnter2D(Collider2D other)
	{
		fini.SetActive(true);
	}
}
