using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	public Transform player;
	private Vector3 PlayerPosition;
	
	private float PosX = -6f;
	private float PosY = 7.25f;
	private float PosZ = -6f;
	private float moveSpeed = 5f;

	void LateUpdate()
	{
		PlayerPosition = player.position + new Vector3 (PosX, PosY, PosZ);
		transform.position = Vector3.MoveTowards(transform.position, PlayerPosition, moveSpeed);
	}
}
