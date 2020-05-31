using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
	public int scene;

	private GameObject inv;

	void Start()
	{
		inv = GameObject.Find("Inventaire");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		SceneManager.LoadScene(sceneBuildIndex: scene);
		
		inv.gameObject.SetActive(true);
	}	

	public void ChangeSceneCutScene()
	{
		SceneManager.LoadScene(sceneBuildIndex: scene);

		inv.gameObject.SetActive(true);
	}
	public void ChangeScenefinal()
	{
		SceneManager.LoadScene(sceneBuildIndex: scene);
	}

}
