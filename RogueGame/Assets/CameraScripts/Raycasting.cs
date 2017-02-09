using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour {

	public GameObject player;
	public PlayerAttack attackScript;
	public static bool queriesHitTriggers;
	// Use this for initialization
	void Start () 
	{
		attackScript = player.GetComponent<PlayerAttack>();
	}
}
