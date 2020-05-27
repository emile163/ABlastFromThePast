using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange1 : MonoBehaviour
{
	
	private GameObject inv;

	void Start()
	{
		inv = GameObject.Find("Inventaire");
	}


	void OnEnable()
	{
		SceneManager.LoadScene(sceneBuildIndex: 2);

		inv.gameObject.SetActive(true);
	}
}
