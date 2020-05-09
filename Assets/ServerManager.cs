using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class ServerManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Server'a bağlanıyoruz.
    }

    public override void OnConnectedToMaster() //Server'a başarılı bir bağlantı kurulduğunda olacaklar
    {
        Debug.Log("servere girildi");

        PhotonNetwork.JoinLobby(); //Lobiye giriş yapıyoruz.
    }

    public override void OnJoinedLobby()
    {

        Debug.Log("Lobiye girildi");

        PhotonNetwork.JoinOrCreateRoom("oda", new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true }, TypedLobby.Default); //Odaya gir giremezsen yeni bir oda kur.

        //PhotonNetwork.JoinRandomRoom(); //Odaya katıl.
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Odaya Girildi");

        GameObject cube = PhotonNetwork.Instantiate("Cube", Vector3.zero, Quaternion.identity,0 , null);
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Odadan Çıkıldı");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Hata: Odaya girilemedi..");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Hata: Random odaya girilemedi...");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Hata: Oda kurulamadı...");
    }

}

























