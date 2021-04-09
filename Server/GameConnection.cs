using System.Collections;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

namespace Assets._Scripts.Server
{
    public class GameConnection : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private TextMeshProUGUI chatLog;
        //----------------------------------------------------------------------------------------------------------

        [Tooltip("Logar onde o player vai nascer")]
        public Vector3 respawPlayerPosition;

        // pedido de conexão com o server
        private void Awake()
        {
            chatLog.text = "Connecting to server...";
            PhotonNetwork.LocalPlayer.NickName = "Player" + "_" + Random.Range(1, 1000);
            PhotonNetwork.ConnectUsingSettings();
        }


        //----------------------------------------------------------------------------------------------------------
        // chamado para entrar na lista de salas
        public override void OnConnectedToMaster()
        {
            // sobescreve comandos da função original
            base.OnConnectedToMaster();

            chatLog.text = "Connect to server!";

            if (PhotonNetwork.InLobby == false)
            {
                chatLog.text = "Entering to lobby...";
                PhotonNetwork.JoinLobby();
            }
        }

        //----------------------------------------------------------------------------------------------------------
        // chamado para entrar em uma sala
        public override void OnJoinedLobby()
        {
            chatLog.text = "In lobby!";

            chatLog.text = "Entering the room Forte...";
            PhotonNetwork.JoinRoom("Forte"); 
        }

        //----------------------------------------------------------------------------------------------------------
        // Aqui nessa função se a sala não exite ela cria uma.
        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            chatLog.text = "Error: entering the room: " + message + " | Code: " + returnCode;

            // retorno de erro
            if (returnCode == ErrorCode.GameDoesNotExist)
            {
                chatLog.text = "Create room Forte...";
                //Cria uma sala com maximo de 20 players
                RoomOptions roomOptions = new RoomOptions { MaxPlayers = 20 };
                // typolobby ultimo parametro nulo, aqui podemos definir um lobe que separa por pais ou versão de jogo;
                // quando uma sala é criada o player ja entra nela automaticamente.
                PhotonNetwork.CreateRoom("Forte", roomOptions, null);
            }
        }

        //----------------------------------------------------------------------------------------------------------
        // metodo executado quando voce(player) entra em uma sala. 
        public override void OnJoinedRoom()
        {
            chatLog.text = "You entered the room Forte";
            chatLog.text = "your nickname is: " + PhotonNetwork.LocalPlayer.NickName;

            //aqui instanciaremos o player na tela
            Vector3 position = new Vector3(Random.Range(respawPlayerPosition.x, respawPlayerPosition.x + 5)
                                           , respawPlayerPosition.y, Random.Range(respawPlayerPosition.z, respawPlayerPosition.z + 5));
            Quaternion rotation = Quaternion.Euler(Vector3.up * Random.Range(0.0f, 360.0f));
            PhotonNetwork.Instantiate("Player", position, rotation);
        }

        //----------------------------------------------------------------------------------------------------------
        // Chamado quando voce sai da sala.
        public override void OnLeftRoom()
        {
            chatLog.text = "You left the room!";
        }

        //----------------------------------------------------------------------------------------------------------
        // verificação quando um player entra na sala
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            chatLog.text = newPlayer.NickName + " player entered the room!";
        }

        //----------------------------------------------------------------------------------------------------------
        // verificação quando um player sai da sala
        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            chatLog.text = otherPlayer.NickName +" player entered the room!";
        }

        //----------------------------------------------------------------------------------------------------------
        // verificação de erro de conexão com o servidor
        public override void OnErrorInfo(ErrorInfo errorInfo)
        {
            chatLog.text = "Error: " + errorInfo;
        }

    }
}