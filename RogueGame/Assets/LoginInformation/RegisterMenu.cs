using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegisterMenu : MonoBehaviour {

	public InputField usernameSlot;
	public InputField passwordSlot;
	public InputField verifySlot;
	public InputField emailSlot;
	public Toggle ageToggle;

	string CreateUserURL = "udriven.atwebpages.com/InsertUsers.php";

	public void RegisterAccount()
	{
		if ((passwordSlot.text == verifySlot.text) && (ageToggle.isOn) && passwordSlot.text != "" && usernameSlot.text != "" && emailSlot.text != "")
		{
			StartCoroutine(CreateUser(usernameSlot.text, passwordSlot.text, emailSlot.text));
		}
		else
		{
			if (passwordSlot.text != verifySlot.text) Debug.Log("Passwords do not match.");
			if (!ageToggle.isOn) Debug.Log("You need to be at least 13 years of age.");
			if (usernameSlot.text == "") Debug.Log("Please enter a valid username.");
			if (passwordSlot.text == "") Debug.Log("Please enter a valid password.");
			if (emailSlot.text == "") Debug.Log("Please enter a valid email.");
		}
	}

	IEnumerator CreateUser(string username, string password, string email)
	{
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", username);
		form.AddField("passwordPost", password);
		form.AddField("emailPost", email);

		WWW www = new WWW(CreateUserURL, form);
		yield return www;
		Debug.Log(www.text);
		if (www.text == "Everything ok.")
		{
			Back_to_Login();
		}
	}
	public void Back_to_Login()
	{
		this.gameObject.SetActive(false);
	}
}
