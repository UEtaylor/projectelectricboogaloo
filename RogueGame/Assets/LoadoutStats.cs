using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadoutStats : NetworkBehaviour {

	public PlayerInfo info;
	public AccountData data;
	public Text userID;
	public Text wep1;
	public Text wep2;
	public Text helm;
	public Text armr;
	public Text boots;
	public Text userRace;
	public Text userClass;

	void Start()
	{
		data = GameObject.Find("AccountInformation").GetComponent<AccountData>();
	} 
	public void UpdateDebugMenu()
	{

		info = data.localPlayer.GetComponent<PlayerInfo>();
		userID.text = "UserID: " + data.userID;
		userRace.text = "Race: " + info.myPlayer.userRace;
		userClass.text = "Class: " + info.myPlayer.userClass;
		helm.text = "HelmID: " + info.myPlayer.helmID;
		armr.text = "ArmourID: " + info.myPlayer.armourID;
		boots.text = "BootsID: " + info.myPlayer.bootsID;
		wep1.text = "Wep1ID: " + info.myPlayer.weapon1;
		wep2.text = "Wep2ID: " + info.myPlayer.weapon2;
	}
}
