using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartClickScript : MonoBehaviour {
	Animator anim;
	int Click = Animator.StringToHash("Click");
	public Canvas myCanvas;
	private Vector3 mousePosition;

	void Start()
	{
		 anim = GetComponent<Animator>();
	}
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			anim.SetTrigger(Click);
			Vector2 pos;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
			transform.position = myCanvas.transform.TransformPoint(pos);
		}
	}

}
