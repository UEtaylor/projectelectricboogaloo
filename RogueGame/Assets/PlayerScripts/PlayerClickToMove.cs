using UnityEngine;
using System.Collections;

public class PlayerClickToMove : MonoBehaviour {

	public float PlayerMoveSpeed;
	public float PlayerRotationSpeed;
	private Vector3 	targetPosition;
	private Quaternion 	targetRotation;
	private Transform PlayerTransform;
 
void Start()
 {
     PlayerTransform = transform;
     targetPosition = PlayerTransform.position;
	 targetRotation = Quaternion.identity;
 }
 
 void Update () 
 {                
     //Amount to move, move speed
     float moveAmount = PlayerMoveSpeed * Time.deltaTime;
	 float rotateSpeed = PlayerRotationSpeed * Time.deltaTime;
     
     //Move the Player after they have clicked the Left Mouse Button on a location
     if (Input.GetMouseButtonDown(0))
     {
         Plane playerPlane = new Plane(Vector3.up, PlayerTransform.position);
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         float hitdist = 0.0f;
         
         if (playerPlane.Raycast(ray, out hitdist)) 
         {
             Vector3 targetPoint = ray.GetPoint(hitdist);
             targetPosition = ray.GetPoint(hitdist);
             targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
         }                        
     }
     transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed);
     PlayerTransform.position = Vector3.MoveTowards(PlayerTransform.position, targetPosition, moveAmount);
 }
}
