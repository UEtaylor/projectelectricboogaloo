using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class AccountData : MonoBehaviour {

	private string LoginLoadURL = "udriven.atwebpages.com/LoginLoadUser.php";
	private string UserLoadouts = "udriven.atwebpages.com/LoadUserLoadouts.php";
	

	public int userID;
	public string userName;
	public string[] Loadouts;
	
	private GameObject LoadoutLoadingGO;

	void Awake() 
	{
        DontDestroyOnLoad(transform.gameObject);
    }

	public void LoadLoadouts()
	{
		StartCoroutine(AcquireUserLoadouts(userID));
	}

	public void LogOutUser()
	{
		userID = -1;
	}

	public IEnumerator AcquireUserInformation(string accountUsername)
	{
		userName = accountUsername;
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", accountUsername);

		WWW www = new WWW(LoginLoadURL, form);
		yield return www; 
		Debug.Log(www.text);

		userID = Convert.ToInt32(www.text);
		StartCoroutine(AcquireUserLoadouts(userID));

	}

	public IEnumerator AcquireUserLoadouts(int accountuserID)
	{
		for (int i = 0; i < Loadouts.Length; i++)
			{
				Loadouts[i] = null;
			}
		WWWForm form = new WWWForm();
		form.AddField("userIDPost", accountuserID);

		WWW acq = new WWW(UserLoadouts, form);
		yield return acq;
		if (acq.text != "empty")
		{
			string loadoutString = acq.text;
			print(loadoutString);
			Loadouts = loadoutString.Split(';');
			for (int i = 0; i < Loadouts.Length - 1; i++)
			{
				Debug.Log(GetDataValue(Loadouts[i], "LoadoutName:"));
			}
		}
		else
		{
			Debug.Log("Account has no current loadouts.");
		}
		StartCoroutine(LoadGame());
	}

	public string GetDataValue(string data, string index)
	{
		string value = data.Substring(data.IndexOf(index) + index.Length);
		if (value.Contains("|"))
		{
			value = value.Remove(value.IndexOf("|"));
		}
		return value;
	}

	public IEnumerator ReloadUserLoadouts()
	{
		LoadoutLoadingGO = GameObject.Find("ClassCreatePanel");
		for (int i = 0; i < Loadouts.Length; i++)
			{
				Loadouts[i] = null;
			}
		WWWForm form = new WWWForm();
		form.AddField("userIDPost", userID);

		WWW acq = new WWW(UserLoadouts, form);
		yield return acq;
		if (acq.text != "empty")
		{
			string loadoutString = acq.text;
			print(loadoutString);
			Loadouts = loadoutString.Split(';');
			for (int i = 0; i < Loadouts.Length - 1; i++)
			{
				Debug.Log(GetDataValue(Loadouts[i], "LoadoutName:"));
			}
			if (LoadoutLoadingGO != null)
			{
				//LoadoutLoadingGO.GetComponent<LoadoutRetrieve>().OpenLoadout();
			}

		}
		else
		{
			Debug.Log("Account has no current loadouts.");
		}
	}

	void FinishLoading()
	{
		SceneManager.LoadScene ("2_mainMenu", LoadSceneMode.Single);
	}

	private IEnumerator LoadGame()
    {
        Debug.Log("Loading Level");
        yield return StartCoroutine("FinishLoading");
    }
}
