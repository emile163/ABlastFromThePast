using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaquingEnemy : MonoBehaviour
{

    public float visionRange;

	public float attaqueRange;

	public float attaquedmg;

	public Transform AngrySignPosition;

	public GameObject AngrySign;

    public float AttackSpeed;

	private PlayerSmg player;

	private GameObject pla;

	private float timer;
	void Start()
	{
		pla = GameObject.FindWithTag("Player");
		player = pla.GetComponent<PlayerSmg>();
		timer = 1 / AttackSpeed;
		
	}

    void Update()
	{
		float distanceToEnemy = Vector2.Distance(transform.position, player.transform.position);
		if (distanceToEnemy <= visionRange)
		{
			timer -= Time.deltaTime;
			if (timer <= 0)
			{
				attaque();
				timer = 1 / AttackSpeed;
			}
		}
	}

	void attaque()
	{
		Instantiate(AngrySign, AngrySignPosition.position, AngrySignPosition.rotation);
		float distanceattaque = Vector2.Distance(transform.position, player.transform.position);
		if (distanceattaque <= attaqueRange)
		{
			player.GetComponent<PlayerSmg>().takedmg(attaquedmg);
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, visionRange);


		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attaqueRange);
	}
}

