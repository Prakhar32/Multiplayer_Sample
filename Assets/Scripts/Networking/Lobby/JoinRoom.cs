using Photon.Pun;
using System;
using TMPro;
using UnityEngine;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public TMP_InputField RoomName;

    void Start()
    {
        if (RoomName == null)
        {
            Destroy(this);
            throw new MissingComponentException("Input Field Missing");
        }
    }

    public void Join()
    {
        if (string.IsNullOrEmpty(RoomName.text))
            throw new InvalidOperationException("Cannot join a room with empty name");
        
        PhotonNetwork.JoinRoom(RoomName.text);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        throw new InvalidOperationException(message);
    }
}
