using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour {

	private int maxHealth = 100;
	public int currentHealth;
	public int str = 5;
	public int speed;

	void Awake()
	{
		currentHealth = maxHealth;
	}

}
