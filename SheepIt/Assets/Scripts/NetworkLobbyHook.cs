using UnityEngine;
using System.Collections;
using Prototype.NetworkLobby;
using UnityEngine.Networking;

public class NetworkLobbyHook : LobbyHook {

    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, 
                                                           GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        PlayerContoller localPlayer = gamePlayer.GetComponent<PlayerContoller>();

        localPlayer.username = lobby.playerName;
        localPlayer.playerColor = lobby.playerColor;
    }
}
