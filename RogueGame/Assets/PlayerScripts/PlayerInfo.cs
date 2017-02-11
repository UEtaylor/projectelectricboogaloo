using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerInfo : NetworkBehaviour {
    public AccountData info;
	public class Player
    {
        [SyncVar]
        public int maxHealth;
        [SyncVar]
        public int currentHealth;
        [SyncVar]
        public int maxStr;
        [SyncVar]
        public int maxSpeed;
        [SyncVar]
        public int weapon1;
        [SyncVar]
        public int weapon2;
        [SyncVar]
        public int attackSpeed;
        [SyncVar]
        public int userRace;
        [SyncVar]
        public int userClass;
        [SyncVar]
        public int armourID;
        [SyncVar]
        public int helmID;
        [SyncVar]
        public int bootsID;


        
        public Player(int hlth, int str, int spd)
        {
            maxHealth = hlth;
            currentHealth = maxHealth;
            maxStr = str;
            maxSpeed = spd;
        }
        
        // Constructor
        public Player()
        {
            maxHealth = 0;
            currentHealth = maxHealth;
            maxStr = 0;
            maxSpeed = 0;
            weapon1 = 0;
            weapon2 = 0;
            attackSpeed = 0;
            
        }
    }
    

  
    public Player myPlayer = new Player();

    public override void OnStartLocalPlayer()
    {
        info = GameObject.Find("AccountInformation").GetComponent<AccountData>();
        info.localPlayer = this.gameObject;
        ConfigurePlayer();
        info.ConfigurePlayerWeapons();
    }
    public void TakeDamage(int damage)
    {
        if (!isServer)
		{
			return;
		}
        myPlayer.currentHealth -= damage;
        Debug.Log(myPlayer.currentHealth);
    }

    public void ConfigurePlayer()
    {
        myPlayer.userRace = int.Parse(info.GetDataValue(info.currentLoadout, "Race:"));
        if (myPlayer.userRace == 0) //Unnamed Small Race
        {
            myPlayer.maxHealth = 60;
            myPlayer.currentHealth = 60;
            myPlayer.maxSpeed   += 1;
            myPlayer.maxStr     -= 3;
        }
        else if (myPlayer.userRace == 1)
        {
            myPlayer.maxHealth = 90;
            myPlayer.currentHealth = 90;
        }
        else if (myPlayer.userRace == 2)
        {
            myPlayer.maxHealth      = 120;
            myPlayer.currentHealth  = 120;
            myPlayer.maxSpeed       -= 1;
            myPlayer.maxStr         += 3;
        }
        else
        {
            Debug.Log("There was an error in locating the selected Race");
        }
        myPlayer.userClass = int.Parse(info.GetDataValue(info.currentLoadout, "Class:"));
        myPlayer.weapon1 = int.Parse(info.GetDataValue(info.currentLoadout, "Wep1-ID:"));
        myPlayer.weapon2 = int.Parse(info.GetDataValue(info.currentLoadout, "Wep2-ID:"));
        myPlayer.armourID = int.Parse(info.GetDataValue(info.currentLoadout, "Armour-ID:"));
        myPlayer.helmID = int.Parse(info.GetDataValue(info.currentLoadout, "Helm-ID:"));
        myPlayer.bootsID = int.Parse(info.GetDataValue(info.currentLoadout, "Boots-ID:"));
    }
}