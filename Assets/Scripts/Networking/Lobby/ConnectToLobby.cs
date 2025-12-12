using Photon.Pun;
using System.Net;

namespace Lobby
{
    public class ConnectToLobby : MonoBehaviourPunCallbacks
    {
        void Start()
        {
            if(PhotonNetwork.IsConnected)
            {
                Destroy(this);
                throw new WebException("Cannot connect if already connected");
            }
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby()
        {
            PhotonNetwork.LoadLevel("LobbyScene");
        }
    }
}