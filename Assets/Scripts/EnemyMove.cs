using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyMove : MonoBehaviour
{

	public Transform player;
	int MoveSpeed = 3;
	int MaxDist = 4;
	int MinDist = 2;




	void Start()
	{

	}

	void Update()
	{
		transform.LookAt(player);

		if (Vector3.Distance(transform.position, player.position) >= MinDist)
		{
			transform.position += transform.forward * MoveSpeed * Time.deltaTime;

		}
	}
}