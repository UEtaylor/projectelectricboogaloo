using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

	public class Player
    {
        public int startingHealth;
        public int currentHealth;
        public int startingStr;
        public int startingSpeed;
        public int projectile1Count;
        public int projectile1Range;
        public int projectile2Count;
        public int projectile2Range;
        public int weapon1Str;
        public int weapon2Str;
        public int projectile1Str;
        public int projectile2Str;
        public int attackSpeed;
        
        public Player(int hlth, int str, int spd)
        {
            startingHealth = hlth;
            currentHealth = startingHealth;
            startingStr = str;
            startingSpeed = spd;
        }
        
        // Constructor
        public Player()
        {
            startingHealth = 150;
            currentHealth = startingHealth;
            startingStr = 5;
            startingSpeed = 3;
            weapon1Str = 3;
            weapon2Str = 5;
            projectile1Str = 5;
            projectile1Count = 3;
            projectile1Range = 7;
            projectile2Str = 11;
            projectile2Count = 3;
            projectile2Range = 7;
            attackSpeed = 1;
            
        }
    }
    

  
    public Player myPlayer = new Player();

    public void TakeDamage(int damage)
    {
        myPlayer.currentHealth -= damage;
        Debug.Log(myPlayer.currentHealth);
    }
}