using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeCut : MonoBehaviour
{
	private static GameObject inv;
	static bool unefois = true;

	void Start()
	{
		if(unefois == true)
		{
			inv = GameObject.Find("Inventaire");
			unefois = false;
		}
	}

	void OnEnable()
	{
		SceneManager.LoadScene(sceneBuildIndex: 3);

		//inv.gameObject.SetActive(true);
	}
}
