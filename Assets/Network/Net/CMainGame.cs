using System;
using System.Collections;
using System.Collections.Generic;
using FreeNet;
using UnityEngine;
using UnityEngine.Device;
using VirusWarGameServer;

public class CMainGame : MonoBehaviour
{
    public static CMainGame current;
    void Awake()
    {
        UnityEngine.Screen.SetResolution(800, 600,false);

        if (current == null)
            current = this;
        else
            Debug.LogError("Not Single CMainGame");
    }

    CNetworkManager network_manager;
    private void Start()
    {
        network_manager = GetComponent<CNetworkManager>();
        network_manager.Connect();
        Debug.Log("NetWorkManagerWorking");
        Invoke("MatchingRoom", 2f);

        //string EX_Name = "Dummy";
        //MatchingRoom(EX_Name);
    }
    public void MatchingRoom()
    {
        string PlayerName = "TestClient Name";
        CPacket msg2 = CPacket.create((short)PROTOCOL.ENTER_GAME_ROOM);
        msg2.push(PlayerName);
        network_manager.send(msg2);
        Debug.Log("MatchingRoomActive");
        Debug.Log(PlayerName);
    }
    public void SendMsg(string chatmsg)
    {
        CPacket msg2 = CPacket.create((short)PROTOCOL.CHAT_MSG);
        msg2.push(chatmsg);
        network_manager.send(msg2);
    }
    public void PLAYER_MOVING_REQ(Vector3 pos,float angle)
    {
        CPacket msg2 = CPacket.create((short)PROTOCOL.PLAYER_MOVING);
        msg2.push(pos.x);
        msg2.push(pos.y);
        msg2.push(pos.z);
        msg2.push(angle);
        network_manager.send(msg2);
    }

    public void PLAYER_SHOOT_REQ(int hitindex)
    {
        CPacket msg = CPacket.create((short)PROTOCOL.PLAYER_SHOOT);
        msg.push(hitindex); 
        network_manager.send(msg);
    }

    public void ENEMY_ATTACK_REQ(int Attackindex)
    {
        CPacket msg = CPacket.create((short)PROTOCOL.ENEMY_ATTACK);
        msg.push(Attackindex);
        network_manager.send(msg);
    }

    public void PlayerName_REQ(int playerindex)
    {
        CPacket msg2 = CPacket.create((short)PROTOCOL.PLAYER_NAME);
        msg2.push(playerindex);
        network_manager.send(msg2);
    }
    public int playerSN = -1;

    public void on_recv(CPacket msg)
    {
        PROTOCOL protocol = (PROTOCOL)msg.pop_protocol_id();
        Console.WriteLine("protocol id " + protocol);
        switch(protocol)
        {
            case PROTOCOL.ENTER_GAME_ROOM: //플레이어
                {
                    playerSN = msg.pop_int32();
                    //ServerObjectManager.current.MoveObject(playerSN,
                    //    Vector3.zero,0, ServerObjectManager.OBJECT_TYPE.PLAYER);
                    Debug.Log("Recieved EnterGameRoom Successfully");
                    Debug.Log("YourSN = " + playerSN);
                }
                break;

            case PROTOCOL.CHAT_MSG:
                {
                    string chat = msg.pop_string();
                    Debug.Log("Protocol Chat_Msg"+chat);
                    //string recvName = msg.pop_string();
                    //string recvmsg = msg.pop_string();
                    //int playerIndex = msg.pop_int32();
                    //ChatWindow.current.ChatCreate(recvName + " : " + recvmsg);

                    //NetObject Findobj = ServerObjectManager.current.FindObject(playerIndex);
                    //if(Findobj != null)
                    //{
                    //    GameObject obj = ObjectManager.current.CreateObejct(0,
                    //        Findobj.transform.position + (Vector3.up * 2f));
                    //    obj.GetComponent<DamageText>().OnText(recvmsg);
                    //}

                }
            break;
            case PROTOCOL.PLAYER_NAME:
                {
                    int playerIndex = msg.pop_int32();
                    string recvName = msg.pop_string();
                    NetObject obj = ServerObjectManager.current.FindObject(playerIndex);
                    if (obj != null)
                    {
                        obj.SetName(recvName);
                    }
                }
                break;

            case PROTOCOL.PLAYER_MOVING:
                {
                    int player_index = msg.pop_int32();
                    float x = msg.pop_float();
                    float y = msg.pop_float();
                    float z = msg.pop_float();
                    float angle = msg.pop_float();
                    byte objectType = msg.pop_byte();

                    //ServerObjectManager.current.MoveObject(player_index,
                    //    new Vector3(x,y,z), angle, (ServerObjectManager.OBJECT_TYPE)objectType);
                }
                break;
            case PROTOCOL.PLAYER_EXIT:
                {
                    int player_index = msg.pop_int32();
                    ServerObjectManager.current.DestroyObject(player_index);
                }
                break;

                //클라이언트 메인 게임
            case PROTOCOL.PLAYER_SHOOT:
                {
                    int player_index = msg.pop_int32();
                    float angle = msg.pop_float();

                    ServerObjectManager.current.PlayerShoot(player_index, angle);
                }
                break;
            case PROTOCOL.PLAYER_HEALTH:
                {
                    int player_index = msg.pop_int32();
                    float hp = msg.pop_float();
                    ServerObjectManager.current.PlayerHealth(player_index, hp);
                }
                break;

            case PROTOCOL.ENEMY_TARGET:
                {
                    //int enemyIndex = msg.pop_int32();
                    //int TargetIndex = msg.pop_int32();
                    //ServerObjectManager.current.ENEMY_TARGET(
                    //    enemyIndex,
                    //    TargetIndex);
                }
                break;


        }
    }
}
