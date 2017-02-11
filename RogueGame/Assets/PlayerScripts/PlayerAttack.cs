using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerAttack : NetworkBehaviour {

	private PlayerInfo info;
	private PlayerMovement move;
	private IEnumerator coroutine;
	public class Weapon
    {
		public int ID;
		public int Str;
		public int Spd;
		public int Range;
		public int Type;
		public GameObject Prefab;
	}

	public Weapon wep1 = new Weapon();
	public Weapon wep2 = new Weapon();
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
			Default_Attack(target);
		}
	}
	
	void Ability_1(GameObject target)
	{
		float damage, range, speed;
		speed = info.myPlayer.attackSpeed;
		range = wep1.Range;
		damage = info.myPlayer.maxStr + wep1.Str;

		GameObject clone = (GameObject)Instantiate(wep1.Prefab, transform.position, transform.rotation);

		clone.GetComponent<RangeWeaponFlight>().SetFlight(this.gameObject, target, 15f, damage);
		
	}
	void Ability_2(GameObject target)
	{
		float damage, range, speed;
		speed = info.myPlayer.attackSpeed;
		range = wep1.Range;
		damage = info.myPlayer.maxStr + wep1.Str;

		GameObject clone = (GameObject)Instantiate(wep1.Prefab, transform.position, transform.rotation);

		clone.GetComponent<RangeWeaponFlight>().SetFlight(this.gameObject, target, 15f, damage);
	}
	void Ability_3(GameObject target)
	{
		float damage, range, speed;
		speed = info.myPlayer.attackSpeed;
		range = wep1.Range;
		damage = info.myPlayer.maxStr + wep1.Str;

		GameObject clone = (GameObject)Instantiate(wep1.Prefab, transform.position, transform.rotation);

		clone.GetComponent<RangeWeaponFlight>().SetFlight(this.gameObject, target, 15f, damage);
	}
	void Ability_4(GameObject target)
	{
		float damage, range, speed;
		speed = info.myPlayer.attackSpeed;
		range = wep1.Range;
		damage = info.myPlayer.maxStr + wep1.Str;

		GameObject clone = (GameObject)Instantiate(wep1.Prefab, transform.position, transform.rotation);

		clone.GetComponent<RangeWeaponFlight>().SetFlight(this.gameObject, target, 15f, damage);
	}
	void Default_Attack(GameObject target)
	{
		float damage, range, speed;
		speed = info.myPlayer.attackSpeed;
		range = wep1.Range;
		damage = info.myPlayer.maxStr + wep1.Str;

		GameObject clone = (GameObject)Instantiate(wep1.Prefab, transform.position, transform.rotation);

		clone.GetComponent<RangeWeaponFlight>().SetFlight(this.gameObject, target, 15f, damage);
	}

	private IEnumerator IsAttacking(float waitTime)
	{
        yield return new WaitForSeconds(waitTime);
		print("Time of attack:  " + Time.time);
        move.attacking = false;
	}
}
