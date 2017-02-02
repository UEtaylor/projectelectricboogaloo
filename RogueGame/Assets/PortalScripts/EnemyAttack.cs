using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public EnemyInfo enemyStats;
	public EnemyNav navigation;
	public IEnumerator coroutine;
	public bool isAttacking = false;

	void Awake()
	{
		navigation = GetComponent<EnemyNav>();
		enemyStats = GetComponent<EnemyInfo>();
	}

	void Update()
	{
		if(navigation.IsClose() && isAttacking == false)
		{
			isAttacking = true;
			Attack();
		}
	}
	void Attack()
	{
		coroutine = AttackDelay(2.0f);
        StartCoroutine(coroutine);
	}
	private IEnumerator AttackDelay(float attackSpeed)
	{
		print("Swings - " + Time.time);
        yield return new WaitForSeconds(attackSpeed);
		if(navigation.IsClose())
		{
			navigation.DamagePlayer(enemyStats.str);
		}
		isAttacking = false;
	}
}
