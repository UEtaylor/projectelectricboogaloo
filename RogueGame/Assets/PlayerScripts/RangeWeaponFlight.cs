using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeaponFlight : MonoBehaviour {

	public Vector3 startPosition;
	public Vector3 endTarget;
	public float flightTime;
	public bool startFlight = false;
	public int damageAmount;
	public GameObject mark;
	float t = 0;

	// Update is called once per frame
	void LateUpdate () 
	{
		t += Time.deltaTime * flightTime;
		if(startFlight)
		{
			transform.position = Vector3.MoveTowards(startPosition, endTarget, t);
			float distanceLeft = Vector3.Distance(transform.position, endTarget);
			if (distanceLeft < 0.25f)
			{
				DeliverDamage();
			}
		}
		transform.LookAt(mark.transform);
	}

	public void SetFlight(GameObject start, GameObject target, float time, float damage)
	{
		mark = target;

		damageAmount = (int) damage;

		startPosition = new Vector3 (start.transform.position.x, start.transform.position.y, start.transform.position.z);

		endTarget = new Vector3 (target.transform.position.x, target.transform.position.y, target.transform.position.z);

		flightTime = time;

		startFlight = true;

	}

	void DeliverDamage()
	{
		mark.SendMessage("TakeDamage", damageAmount);
		Destroy();
	}
	void Destroy()
	{
		Destroy(gameObject);
	}
}
