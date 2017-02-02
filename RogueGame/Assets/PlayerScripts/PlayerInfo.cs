using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

	public class Race
    {
        public int startingHealth;
        public int currentHealth;
        public int startingStr;
        public float startingSpeed;
        public float mana;
        
        public Race(int hlth, int str, float spd)
        {
            startingHealth = hlth;
            currentHealth = startingHealth;
            startingStr = str;
            startingSpeed = spd;
        }
        
        public Race(int hlth, int str, float spd, float m)
        {
            startingHealth = hlth;
            currentHealth = startingHealth;
            startingStr = str;
            startingSpeed = spd;
            mana = m;
        }
        
        // Constructor
        public Race()
        {
            startingHealth = 150;
            currentHealth = startingHealth;
            startingStr = 100;
            startingSpeed = 3;
        }
    }
    

    // Creating an Instance (an Object) of the Race class
    public Race myRace = new Race();
    
    void Start()
    {
        Debug.Log(myRace.startingHealth);
    }
    public void TakeDamage(int damage)
    {
        myRace.currentHealth -= damage;
        Debug.Log(myRace.currentHealth);
    }
}