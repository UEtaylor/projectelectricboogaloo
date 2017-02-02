using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(UnityEngine.AI.NavMesh))]
public class EnemyNav : MonoBehaviour {


	public float closestDistance = 5; //Distance that enemys become perma-aggro.
	public float distance; //Distance that it is from the nearest player.
	public Vector3 	targetPosition;
	public Transform EnemyTransform;
	public GameObject[] PlayerTransforms;
	public GameObject closestPlayer;
    UnityEngine.AI.NavMeshAgent agent;

void Awake()
{
    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	PlayerTransforms =  GameObject.FindGameObjectsWithTag("Player");
}
void Start()
 {
     EnemyTransform = transform;
     targetPosition = EnemyTransform.position;
 }
 
 void Update () 
 {   
	 FindNearestPlayer();
 }
 void FindNearestPlayer()
 {
	 foreach (GameObject currentPlayer in PlayerTransforms)
	 {
		 distance = Vector3.Distance(currentPlayer.transform.position, transform.position);
		 if (closestDistance > distance)
		 {
			 SetTargetPosition(currentPlayer.transform);
			 closestPlayer = currentPlayer;
		 }
	 }
 }
 void SetTargetPosition(Transform targetPlayer)
 {   
	 targetPosition = targetPlayer.position;
	 if (!IsClose())  
	 {          
     	MoveEnemy();
	 }
	 else
	 {
		 StopEnemy();
	 }
 }
 public bool IsClose()
 {
	 if (distance < 1.4f)
	 {
		 return true;
	 }
	 else
	 	return false;
 }
 void MoveEnemy()
 {
    //Amount to move, move speed
    //float moveAmount = EnemyM * Time.deltaTime;
	//float rotateSpeed = PlayerRotationSpeed * Time.deltaTime;

    //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed);
    //EnemyTransform.position = Vector3.MoveTowards(EnemyTransform.position, targetPosition, moveAmount);
    
    agent.SetDestination(targetPosition);
    Debug.DrawLine(EnemyTransform.position, targetPosition, Color.red);
 }
 void StopEnemy()
 {
	 agent.SetDestination(transform.position);
 }

 public void DamagePlayer(int damage)
 {
	 closestPlayer.GetComponent<PlayerInfo>().TakeDamage(damage);
 }
}

