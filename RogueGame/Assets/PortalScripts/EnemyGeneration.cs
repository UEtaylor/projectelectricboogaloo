using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour {

	public class Enemy
    {
        public int startingHealth;
        public int startingStr;
        public float startingSpeed;
        
        public Enemy(int hlth, int str, float spd)
        {
            startingHealth = hlth;
            startingStr = str;
            startingSpeed = spd;
        }
        
        // Constructor
        public Enemy()
        {
            startingHealth = 150;
            startingStr = 100;
            startingSpeed = 1;
        }
    }
    

    // Creating an Instance (an Object) of the Enemy class
    public Enemy myEnemy = new Enemy();
    
    public Enemy myOtherEnemy = new Enemy(150, 50, 0.8f);
    
    void Start()
    {
        Debug.Log(myEnemy.startingHealth);
    }
}
