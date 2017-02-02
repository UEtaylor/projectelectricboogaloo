using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(UnityEngine.AI.NavMesh))]
public class PlayerClickToMove : MonoBehaviour {

	private Vector3 	targetPosition;
	private Transform   PlayerTransform;
    UnityEngine.AI.NavMeshAgent agent;

void Awake()
{
    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
}
void Start()
 {
     PlayerTransform = transform;
     targetPosition = PlayerTransform.position;
 }
 
 void Update () 
 {                
     SetTargetPosition();
 }
 void SetTargetPosition()
 {
     //Move the Player after they have clicked the Left Mouse Button on a location
     if (Input.GetMouseButtonDown(0))
     {
         Plane playerPlane = new Plane(Vector3.up, PlayerTransform.position);
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         float hitdist = 0.0f;
         
         if (playerPlane.Raycast(ray, out hitdist)) 
         {
             //Vector3 targetPoint = ray.GetPoint(hitdist);
             targetPosition = ray.GetPoint(hitdist);
             //targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
         }                        
     }
     MovePlayer();
 }
 void MovePlayer()
 {
    //Amount to move, move speed
    //float moveAmount = PlayerMoveSpeed * Time.deltaTime;
	//float rotateSpeed = PlayerRotationSpeed * Time.deltaTime;

    //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed);
    //PlayerTransform.position = Vector3.MoveTowards(PlayerTransform.position, targetPosition, moveAmount);
    
    agent.SetDestination(targetPosition);
    Debug.DrawLine(PlayerTransform.position, targetPosition, Color.green);
 }
}
