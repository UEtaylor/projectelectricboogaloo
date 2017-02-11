using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class AccountData : MonoBehaviour
{

    private string LoginLoadURL = "udriven.atwebpages.com/LoginLoadUser.php";
    private string UserLoadouts = "udriven.atwebpages.com/LoadUserLoadouts.php";


    public int userID;
    public string userName;
    public string[] Loadouts;
	public string currentLoadout;
    public GameObject localPlayer;
    private PlayerAttack weaponSettings;

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

        WWW response = new WWW(UserLoadouts, form);
        yield return response;
        if (response.text != "empty")
        {
            string loadoutString = response.text;
            Loadouts = loadoutString.Split(';');
            for (int i = 0; i < Loadouts.Length - 1; i++)
            {
                Debug.Log(GetDataValue(Loadouts[i], "Loadout-Name:"));
            }
        }
        else
        {
            Debug.Log("Account has no current loadouts.");
        }
        Debug.Log(Loadouts.Length);
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

        WWW response = new WWW(UserLoadouts, form);
        yield return response;
        if (response.text != "empty")
        {
            string loadoutString = response.text;
            print(loadoutString);
            Loadouts = loadoutString.Split(';');
            for (int i = 0; i < Loadouts.Length - 1; i++)
            {
                Debug.Log(GetDataValue(Loadouts[i], "Loadout-Name:"));
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
        SceneManager.LoadScene("2_mainMenu", LoadSceneMode.Single);
    }

    private IEnumerator LoadGame()
    {
        Debug.Log("Loading Level");
        yield return StartCoroutine("FinishLoading");
    }

    public void LoadCurrentLoadout(int num)
    {
        currentLoadout = Loadouts[num];
    }
    public void ConfigurePlayerWeapons()
    {
        LoadWeaponData data = GetComponent<LoadWeaponData>();
        data.LoadWeapons(int.Parse(GetDataValue(currentLoadout, "Wep1-ID:")), this);
        data.LoadWeapons(int.Parse(GetDataValue(currentLoadout, "Wep2-ID:")), this);
    }
    public void LoadWeaponString(string data) 
    { //Run this when the game starts
        if (localPlayer != null)
        {
            weaponSettings = localPlayer.GetComponent<PlayerAttack>();
            weaponSettings.wep1.ID      = int.Parse(GetDataValue(data, "Weapon-ID:"));
            weaponSettings.wep1.Type    = int.Parse(GetDataValue(data, "Weapon-Type:"));
            weaponSettings.wep1.Str     = int.Parse(GetDataValue(data, "Weapon-Str:"));
            weaponSettings.wep1.Spd     = int.Parse(GetDataValue(data, "Weapon-Spd:"));
            weaponSettings.wep1.Range   = int.Parse(GetDataValue(data, "Weapon-Range:"));
            weaponSettings.wep1.Prefab  = (GameObject)Resources.Load("Prefabs/Weapons/" + GetDataValue(data, "Weapon-ID:") + "_weapon", typeof(GameObject));
            Debug.Log(weaponSettings.wep1.Prefab);
        }
        else
        {
            Debug.Log("There was an error finding the local player.");
        }
    }
}
