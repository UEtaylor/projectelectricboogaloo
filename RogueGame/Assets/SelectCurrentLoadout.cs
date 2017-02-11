using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCurrentLoadout : MonoBehaviour {
	
	private AccountData accountInfo;
	public GameObject loadoutButton;
	private Button btn;
	void Start()
	{
		accountInfo = GameObject.Find("AccountInformation").GetComponent<AccountData>();
		MakeList(accountInfo.Loadouts);
	}

	void MakeList(string[] loadouts)
	{ 	
		int i = 0;
		foreach (string x in loadouts)
		{
			if (x != "")
			{
				GameObject newButton = Instantiate(loadoutButton) as GameObject;
				newButton.transform.SetParent(this.gameObject.transform);
				newButton.GetComponentInChildren<Text>().text = accountInfo.GetDataValue(x, "Loadout-Name:");
				newButton.GetComponent<LoadoutSelectionButton>().num = i;
			}
			i++;
		}
	}
}
