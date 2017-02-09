using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayNameMenu : MonoBehaviour {

	public AccountData accountData;

	void Start()
	{
		accountData = GameObject.Find("AccountInformation").GetComponent<AccountData>();
		GetComponent<Text>().text = accountData.userName;
	}
}
