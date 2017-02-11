using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnviromentHealth : NetworkBehaviour {

	[SyncVar]
	public int maxHealth;
	[SyncVar]
	public int currentHealth;
	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
	}
	
	public void TakeDamage(int damage)
    {
		if (!isServer)
		{
			return;
		}
        currentHealth = currentHealth - damage;
        Debug.Log(currentHealth);
    }
}
