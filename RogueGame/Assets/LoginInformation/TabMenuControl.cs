using UnityEngine;
using System.Collections;

public class TabMenuControl : MonoBehaviour {

public GameObject meleeTab;
public GameObject rangeTab;
public GameObject trapTab;
public GameObject itemTab;

	// Use this for initialization
	void Start () {
		meleeTab = transform.FindChild("MeleeTab").gameObject;
		rangeTab = transform.FindChild("RangeTab").gameObject;
		trapTab = transform.FindChild("TrapTab").gameObject;
		itemTab = transform.FindChild("ItemTab").gameObject;
		meleeTab.SetActive(false);
		rangeTab.SetActive(false);
		trapTab.SetActive(false);
		itemTab.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

public void ChangeTab(int tabNumber) {

	switch (tabNumber)
		{
		case 1:
			meleeTab.SetActive(false);
			rangeTab.SetActive(true);
			trapTab.SetActive(false);
			itemTab.SetActive(false);
			break;
		case 2:
			meleeTab.SetActive(false);
			rangeTab.SetActive(false);
			trapTab.SetActive(true);
			itemTab.SetActive(false);
			break;
		case 3:
			meleeTab.SetActive(false);
			rangeTab.SetActive(false);
			trapTab.SetActive(false);
			itemTab.SetActive(true);
			break;
		default:
			meleeTab.SetActive(true);
			rangeTab.SetActive(false);
			trapTab.SetActive(false);
			itemTab.SetActive(false);
			break;
		}
	}

}
