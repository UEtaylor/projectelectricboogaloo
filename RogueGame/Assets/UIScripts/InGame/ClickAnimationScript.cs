using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimationScript : MonoBehaviour {

	public Canvas myCanvas;
	private Vector3 mousePosition;

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Vector2 pos;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
			transform.position = myCanvas.transform.TransformPoint(pos);
		}
	}
}
