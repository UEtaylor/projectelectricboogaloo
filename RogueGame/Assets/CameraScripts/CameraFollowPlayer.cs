using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	public Transform player;
	private Vector3 PlayerPosition;
	
	private float PosX = -15f;
	private float PosY = 25.6f;
	private float PosZ = -15f;
	private float moveSpeed = 5f;

	void LateUpdate()
	{
		PlayerPosition = player.position + new Vector3 (PosX, PosY, PosZ);
		transform.position = Vector3.MoveTowards(transform.position, PlayerPosition, moveSpeed);
	}
}
