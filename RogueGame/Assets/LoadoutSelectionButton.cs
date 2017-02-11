using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadoutSelectionButton : MonoBehaviour {
	
	public AccountData info;
	public int num = 0;
	private Button b;
	// Update is called once per frame

	void Start()
	{
		Button b = gameObject.GetComponent<Button>();
		b.onClick.AddListener(this.onClick);
	}
	void onClick () 
	{
		info = GameObject.Find("AccountInformation").GetComponent<AccountData>();
		info.LoadCurrentLoadout(num);
	}
}
