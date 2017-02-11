using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LoginMenu : MonoBehaviour
{

    public InputField usernameSlot;
    public InputField passwordSlot;
    public AccountData accountData;
    public GameObject RegisterPage;

    string LoginUserURL = "udriven.atwebpages.com/Login.php";

    void Awake()
    {
        RegisterPage.SetActive(false);
    }

    public void LoginUserButton()
    {
        StartCoroutine(LoginUser(usernameSlot.text, passwordSlot.text));
    }

    public void ToRegisterPage()
    {
        RegisterPage.SetActive(true);
    }

    IEnumerator LoginUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        WWW www = new WWW(LoginUserURL, form);
        yield return www;
        Debug.Log(www.text);
        if (www.text == "#001000")
        {
            StartCoroutine(accountData.AcquireUserInformation(username));
        }
    }

}
