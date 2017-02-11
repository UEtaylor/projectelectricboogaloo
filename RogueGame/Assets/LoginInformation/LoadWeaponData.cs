using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LoadWeaponData : MonoBehaviour
{
    string LoginUserURL = "udriven.atwebpages.com/WeaponData.php";


    public void LoadWeapons(int weapon_id, AccountData x)
    {
        StartCoroutine(AccessWeaponData(weapon_id, x));
    }

    IEnumerator AccessWeaponData(int weapon_id, AccountData x)
    {
        WWWForm form = new WWWForm();
        form.AddField("wepPost", weapon_id);

        WWW response = new WWW(LoginUserURL, form);
        yield return response;

        if (response.text != "empty")
        {
            x.LoadWeaponString(response.text);
        }
        else
        {
            Debug.Log("There are no weapons currently with that ID.");
        }

    }
}
