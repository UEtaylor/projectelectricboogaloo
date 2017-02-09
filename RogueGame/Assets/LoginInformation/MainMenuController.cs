using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuController : MonoBehaviour {

	public GameObject menuBackButton;
	public AccountData accountData;
	private Transform[] children;
	public List<Transform> menuPages = new List<Transform>();

	void Awake()
	{
		accountData = GameObject.Find("AccountInformation").GetComponent<AccountData>();
		Transform[] children = transform.GetComponentsInChildren<Transform>();
		foreach (Transform child in children)
		{
			if (child.parent == transform)
			{
				menuPages.Add(child);
			}
		}
	}
	void Start()
	{
		menuPages[2].gameObject.SetActive(false);
		menuPages[3].gameObject.SetActive(false);
		menuPages[4].gameObject.SetActive(false);
		menuPages[5].gameObject.SetActive(false);
		menuPages[6].gameObject.SetActive(false);
		menuBackButton.gameObject.SetActive(false);
	}

	public void TogglePanelDelay(int num)
	{
		StartCoroutine(ToggleVerify(num));
	}
	private IEnumerator ToggleVerify(int num)
	{
		yield return new WaitForSeconds(2f);
		if(accountData.userID > 0)
		{
			if (menuPages[num].gameObject.activeSelf)
			{
				menuPages[num].gameObject.SetActive(false);
			}
			else
			{
				menuPages[num].gameObject.SetActive(true);
			}
		}
	}
	public void TogglePanel(int num)
	{
		if(accountData.userID > 0)
		{
			if (menuPages[num].gameObject.activeSelf)
			{
				menuPages[num].gameObject.SetActive(false);
			}
			else
			{
				menuPages[num].gameObject.SetActive(true);
			}
		}
	}
	public void LogOutUser()
	{
		//Load LoginMenu Scene

	}
}
