using Photon.Pun;
using TMPro;
using UnityEngine;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    public TMP_InputField RoomName;

    private void Start()
    {
        if(RoomName == null)
        {
            Destroy(this);
            throw new MissingComponentException("Input Field Missing");
        }
    }

    public void Create()
    {
        string roomName = RoomName.text;
        if (string.IsNullOrEmpty(roomName))
            throw new System.InvalidOperationException("Cannot create a room with empty name");

        bool roomCreated = PhotonNetwork.CreateRoom(roomName);

        if(!roomCreated) 
            throw new System.InvalidOperationException("Cannot create a new room");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(CommonConstants.GameplayScene);
    }
}
