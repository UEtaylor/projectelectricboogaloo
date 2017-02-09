using UnityEngine;
using UnityEngine.Networking;

public class ConfigureGame : NetworkBehaviour {
    void OnPlayerConnected(NetworkPlayer player) {
        Debug.Log("Player" + " connected from " + player.ipAddress + ":" + player.port);
    }
}
