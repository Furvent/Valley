using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Lobby : NetworkLobbyManager {

	// Use this for initialization
	void Start ()
    {
	    
	}

    public override void OnLobbyStartHost()
    {
        base.OnLobbyStartHost();
        Debug.Log("First test, OnLobbyStartHost");
    }

    public override void OnLobbyStartServer()
    {
        base.OnLobbyStartServer();
        Debug.Log("First test, OnLobbyStartServer");
    }

    public void OnLobbyServerCreateLobbyPlayer()
    {
        Debug.Log("First test, OnLobbyServerCreateLobbyPlayer");
    }
}
