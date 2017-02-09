using UnityEngine;
using System.Collections;

public class UserRegistration : MonoBehaviour {

	public string inputUSERNAME;
	public string inputPASSWORD;
	public string inputEMAIL;
	public int inputAGE;

	string CreateUserURL = "udriven.atwebpages.com/InsertUsers.php";

	// Use this for initialization
	void Start () {
	
	}

	public void CreateUser(string username, string password, string email, int age)
	{
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", username);
		form.AddField("passwordPost", password);
		form.AddField("emailPost", email);
		form.AddField("agePost", age);

		WWW www = new WWW(CreateUserURL, form);
	}
}
