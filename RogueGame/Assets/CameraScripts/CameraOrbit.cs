using UnityEngine;
using UnityEngine.Networking;

public class CameraOrbit : NetworkBehaviour {
 
    public float turnSpeed = 4.0f;
    public Transform player;
    private Vector3 offset;
 
    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }
        if (Input.GetMouseButton(2))
        {
           offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        }
        transform.position = player.position + offset; 
        transform.LookAt(player.position);
    }
    public void LoadPlayer(Transform localPlayer)
    {
        player = localPlayer;
        offset = new Vector3(player.position.x - 15.0f, player.position.y + 26.6f, player.position.z - 15.0f);
    }
}