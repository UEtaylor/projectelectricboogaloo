using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentHealth : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
	}
	
	public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        Debug.Log(currentHealth);
    }
}
