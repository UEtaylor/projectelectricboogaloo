using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerAttack : NetworkBehaviour {

	private PlayerInfo info;
	private PlayerMovement move;
	private int currentAttack;
	private IEnumerator coroutine;
	public GameObject projectile1Prefab;
	public GameObject projectile2Prefab;
	void Start()
	{
		if (!isLocalPlayer)
		{
			return;
		}
		move = GetComponent<PlayerMovement>();
		info = GetComponent<PlayerInfo>();
	}

	void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}
		int layerMask = 1 << 8;
		if (Input.GetMouseButtonDown(1) && move.attacking == false)
        {
            Debug.Log("Attempt");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
				AttackProcess(hit.transform.gameObject);
            }
        }
	}
	void AttackProcess(GameObject target) 
	{
		Debug.Log("Player Attacked!");

		move.LookTowards(target.transform);

		float distance = Vector3.Distance(transform.position, target.transform.position);
		//Melee range is standard 1.5f
		//Projectile range is dynamically given

		coroutine = IsAttacking(info.myPlayer.attackSpeed);

		StartCoroutine(coroutine);
		/*
			- **Test if you are attacking yourself** will wait until LocalPlayer is added
			- Is it a projectile or a melee attack?
			- Projectile:
				- Get target location 
				- Calc distance
				- Check if in range
				- Spawn projectile
				- Attach target position, and damage
			- Melee:
				- Swing weapon
				- If it collided with a tag of "attackable"
				- SendMessage of TakeDamage( damage amount)
		*/
		//Attack Style Selection
		if (Input.GetKey(KeyCode.Q)) 
		{
			Ability_1(target);
		}
		else if (Input.GetKey(KeyCode.W))
		{
			Ability_2(target);
		}
		else if (Input.GetKey(KeyCode.E))
		{
			Ability_3(target);
		}
		else if (Input.GetKey(KeyCode.R))
		{
			Ability_4(target);
		}
		else
		{
			Ability_5(target);
		}
	}
	
	void Ability_1(GameObject target)
	{
		bool melee = true;
		float range, damage, speed;
		speed = info.myPlayer.attackSpeed;
		if(melee)
		{
			range = 1.5f;
			damage = info.myPlayer.weapon1Str + info.myPlayer.startingStr;
		}
		else
		{
			range = info.myPlayer.projectile1Range;
			damage = info.myPlayer.startingStr + info.myPlayer.projectile1Str;

			GameObject clone = (GameObject)Instantiate(projectile2Prefab, transform.position, transform.rotation);

			int damageAmount = info.myPlayer.startingStr + info.myPlayer.projectile1Str;

			clone.GetComponent<RangeWeaponFlight>().SetFlight(this.gameObject, target, 15f, damage);
		}
	}
	void Ability_2(GameObject target)
	{

	}
	void Ability_3(GameObject target)
	{

	}
	void Ability_4(GameObject target)
	{
		GameObject clone = (GameObject)Instantiate(projectile2Prefab, transform.position, transform.rotation);

		int damageAmount = info.myPlayer.startingStr + info.myPlayer.projectile1Str;

		clone.GetComponent<RangeWeaponFlight>().SetFlight(this.gameObject, target, 15f, damageAmount);
	}
	void Ability_5(GameObject target)
	{
		GameObject clone = (GameObject)Instantiate(projectile1Prefab, transform.position, transform.rotation);

		int damageAmount = info.myPlayer.startingStr + info.myPlayer.projectile2Str;

		clone.GetComponent<RangeWeaponFlight>().SetFlight(this.gameObject, target, 15f, damageAmount);
	}

	private IEnumerator IsAttacking(float waitTime)
	{
        yield return new WaitForSeconds(waitTime);
		print("Time of attack:  " + Time.time);
        move.attacking = false;
	}
}
