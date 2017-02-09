using UnityEngine;
using System.Collections;

public class StoreDataLoader : MonoBehaviour {

	public string[] storeItems;

	// Use this for initialization
	IEnumerator Start() {
		WWW storeData = new WWW("localhost/_ridges_top/StoreData.php");
		yield return storeData;
		string storeDataString = storeData.text;
		print(storeDataString);
		storeItems = storeDataString.Split(';');
		for (int i = 0; i < storeItems.Length - 1; i++)
		{
			Debug.Log(GetDataValue(storeItems[i], "Name:"));
		}
	}
	
	string GetDataValue(string data, string index)
	{
		string value = data.Substring(data.IndexOf(index) + index.Length);
		if (value.Contains("|"))
		{
			value = value.Remove(value.IndexOf("|"));
		}
		return value;
	}
	
}
