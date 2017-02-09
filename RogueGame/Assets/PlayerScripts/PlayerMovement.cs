using UnityEngine;
using UnityEngine.Networking;

[DisallowMultipleComponent]
[RequireComponent(typeof(UnityEngine.AI.NavMesh))]
public class PlayerMovement : NetworkBehaviour {

    public GameObject walkIcon;
    public GameObject camera;
	private Vector3 	targetPosition;
    public bool attacking = false;
    private Transform target;
    public float rotationSpeed;
    UnityEngine.AI.NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    public override void OnStartLocalPlayer()
    {
        targetPosition = transform.position;
        camera = GameObject.FindWithTag("MainCamera");
        camera.GetComponent<CameraOrbit>().LoadPlayer(this.gameObject.transform);
    }
    
    void Update () 
    {
        if (!isLocalPlayer)
		{
			return;
		}
        SetTargetPosition();
        if (attacking)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.position), rotationSpeed * Time.deltaTime);
        }
    }
    void SetTargetPosition()
    {
        //Move the Player after they have clicked the Left Mouse Button on a location
        if (Input.GetMouseButtonDown(0))
        {
            Plane playerPlane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float leftClickdist = 0.0f;
        
            if (playerPlane.Raycast(ray, out leftClickdist)) 
            {
                targetPosition = ray.GetPoint(leftClickdist);
            
                Instantiate(walkIcon, targetPosition, Quaternion.identity);
            }                        
        }
        MovePlayer();
    }
    void MovePlayer()
    {
        agent.SetDestination(targetPosition);
        Debug.DrawLine(transform.position, targetPosition, Color.green);
    }
    public void LookTowards(Transform acqTarget)
    {
        targetPosition = transform.position;
        target = acqTarget;
        attacking = true;
    }
}
