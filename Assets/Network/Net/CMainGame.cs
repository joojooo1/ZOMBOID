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

    public bool IsConnecting;
    public bool Multiplaying;
    public int playerSN = -1;
    public bool Is_Host = false;

    public GameObject[] Zombie_Spawn_Point;
    public GameObject[] Zombie_ReSpawn;

    public int ZomSN_Started_Thu;

    void Awake()
    {
        UnityEngine.Screen.SetResolution(800, 600, false);

        if (current == null)
            current = this;
        else
            Debug.LogError("Not Single CMainGame");
        IsConnecting = false;
        Multiplaying = false;
        playerSN = -1;
    }

    CNetworkManager network_manager;
    private void Start()
    {
        ZomSN_Started_Thu = 1000;
        network_manager = GetComponent<CNetworkManager>();
        //if (CNetworkManager.CNetManager.Multiplayer == true)
        //{
        //    network_manager.Connect();
        //    Debug.Log("NetWorkManagerWorking");
        //    Invoke("MatchingRoom", 2f);

        //    //string EX_Name = "Dummy";
        //    //MatchingRoom(EX_Name);
        //}
        UnityEngine.Screen.SetResolution(1920, 1080, false);
    }

    public void Connecting_Req()
    {
        IsConnecting = true;
    }

    public void Connecting_Cancle()
    {
        IsConnecting = false;
    }

    public void TryringToGetInMultiplayer()
    {
        //network_manager = GetComponent<CNetworkManager>();
        if (IsConnecting)
        {
            network_manager.Connect();
            Debug.Log("NetWorkManagerWorking");
            Invoke("MatchingRoom", 2f);

            //string EX_Name = "Dummy";
            //MatchingRoom(EX_Name);
        }
    }

    public void MatchingRoom()
    {
        string PlayerName = "TestClient Name";
        Multiplaying = true;
        IsConnecting = false;
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
    public void PLAYER_MOVING_REQ(Vector3 pos, float angle)
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

    public void Player_Animation_Send(string Ani, int Tof, float floatt, int setting)
    {
        CPacket msg = CPacket.create((short)PROTOCOL.PLAYER_ANIMATION);
        msg.push(playerSN);
        msg.push(Ani);
        msg.push(Tof);
        msg.push(floatt);
        msg.push(setting);
        network_manager.send(msg);
    }

    public void Inv_Sync(CPacket InvPacket)
    {
        network_manager.send(InvPacket);
    }

    public void Is_Active_Player(NetObject net)
    {
        bool Result = false;

        if (net.player_index == playerSN)
        {
            Result = true;
            net.gameObject.GetComponentInChildren<player_movement>().Player = Result;
            net.gameObject.GetComponentInChildren<player_rot>().Player = Result;
            foreach (player_animation anime in net.gameObject.GetComponentsInChildren<player_animation>())
            {
                anime.Player = Result;
            }
        }
        else
        {
            net.gameObject.GetComponentInChildren<player_movement>().Player = Result;
            net.gameObject.GetComponentInChildren<player_rot>().Player = Result;
            foreach (player_animation anime in net.GetComponentsInChildren<player_animation>())
            {
                net.gameObject.GetComponentInChildren<player_animation>().Player = Result;
            }
        }


    }

    public void Player_Rotation_Sending_Req(Quaternion Rotation)
    {
        CPacket msg = CPacket.create((short)PROTOCOL.PLAYER_ROTATION);
        msg.push(playerSN);
        msg.push(Rotation.x);
        msg.push(Rotation.y);
        msg.push(Rotation.z);
        msg.push(Rotation.w);

        network_manager.send(msg);
    }

    //수신 메인
    public void on_recv(CPacket msg)
    {
        PROTOCOL protocol = (PROTOCOL)msg.pop_protocol_id();
        Console.WriteLine("protocol id " + protocol);
        switch (protocol)
        {
            case PROTOCOL.ENTER_GAME_ROOM: //플레이어
                {
                    int psn = msg.pop_int32();

                    if (playerSN == -1)
                    {
                        playerSN = psn;
                        Debug.Log("YourSN = " + playerSN);
                        ServerObjectManager.current.MoveObject(psn, Vector3.zero, 0, ServerObjectManager.OBJECT_TYPE.PLAYER);
                    }
                    int IsH = msg.pop_int32();

                    if (IsH == 1)
                    {
                        Is_Host = true;
                        //자기 맵생성, db생성 시작
                        foreach(GameObject ZSP in Zombie_Spawn_Point)
                        {
                            ZSP.SetActive(true);
                            foreach(GameObject zombie_Name_Nav in ZSP.GetComponent<respawn_Controller>().zom_nav)
                            {
                                zombie_Name_Nav.gameObject.SetActive(true);
                                zombie_Name_Nav.GetComponent<zom_pos>().ZOM_SN = ZomSN_Started_Thu;
                                ZomSN_Started_Thu++;
                                
                                CPacket msg_Zom = CPacket.create((short)PROTOCOL.HOST_ZOM_SPAWN);
                                msg_Zom.push(zombie_Name_Nav.GetComponent<zom_pos>().ZOM_SN);
                                float x = zombie_Name_Nav.gameObject.transform.position.x;
                                float y = zombie_Name_Nav.gameObject.transform.position.y;
                                float z = zombie_Name_Nav.gameObject.transform.position.z;
                                msg_Zom.push(x);
                                msg_Zom.push(y);
                                msg_Zom.push(z);
                                network_manager.send(msg_Zom);
                            }
                        }
                        Debug.Log("You are Host");
                    }
                    else if (IsH == 0)
                    {
                        //맵은 생성, db 생성하지않음*
                        CPacket msg2 = CPacket.create((short)PROTOCOL.FIRST_SYNC_REQ);
                        msg2.push(playerSN);
                        network_manager.send(msg2);
                        Debug.Log("You are player. Requesting Packages From host. Your SN = " + playerSN);
                        
                    }
                    else
                    {
                        Debug.Log("SomeOneEntering");
                        ServerObjectManager.current.MoveObject(psn, Vector3.zero, 0, ServerObjectManager.OBJECT_TYPE.PLAYER);
                    }
                    //ServerObjectManager.current.MoveObject(playerSN,
                    //    Vector3.zero, 0, ServerObjectManager.OBJECT_TYPE.PLAYER);
                }
                break;

            case PROTOCOL.CHAT_MSG:
                {
                    string chat = msg.pop_string();
                    Debug.Log("Protocol Chat_Msg" + chat);
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
                    if (playerSN != -1)
                    {
                        int player_index = msg.pop_int32();
                        float x = msg.pop_float();
                        float y = msg.pop_float();
                        float z = msg.pop_float();
                        float angle = msg.pop_float();
                        byte objectType = msg.pop_byte();

                        ServerObjectManager.current.MoveObject(player_index,
                            new Vector3(x, y, z), angle, (ServerObjectManager.OBJECT_TYPE)objectType);
                    }
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
            case PROTOCOL.INV_SYNCHRONIZATION:
                {
                    int Location_Info = msg.pop_int32();
                    int Basic_Info = msg.pop_int32();
                    int Before_Info = msg.pop_int32();
                    Debug.Log("loc" + Location_Info);
                    Debug.Log("Basic" + Basic_Info);

                    int XLoc = (Location_Info - 1000000000) / 100000000;
                    int YLoc = (Location_Info % 100000000) / 1000000;
                    int Order = (Location_Info % 1000000) / 1000;

                    int Type = (Basic_Info - 10000000) / 1000000;
                    int ID = (Basic_Info % 100000) / 1000;
                    int Amount = Basic_Info % 1000;
                    int Direction = (Basic_Info % 1000000) / 100000;

                    int Before_X = (Before_Info - 1000) / 100;
                    int Before_Y = (Before_Info - 1000) % 100;

                    //( 1면 type / 2면, id / 3면 갯수 / 4면 방향 / 5면 특수정보)
                    Inventory_Library.IL.Inventory_DB[Order][0, (short)XLoc, (short)YLoc] = (short)Type;
                    Inventory_Library.IL.Inventory_DB[Order][1, (short)XLoc, (short)YLoc] = (short)ID;
                    Inventory_Library.IL.Inventory_DB[Order][2, (short)XLoc, (short)YLoc] = (short)Amount;
                    Inventory_Library.IL.Inventory_DB[Order][3, (short)XLoc, (short)YLoc] = (short)Direction;
                    Debug.Log("Library Number " + Order);
                    Debug.Log("Type changed to " + Type);
                    Debug.Log("ID changed to " + ID);
                    Debug.Log("Amount changed to " + Amount);
                    Debug.Log("Direction changed to " + Direction);

                    for (int Depth = 0; Depth < 5; Depth++)
                    {
                        Inventory_Library.IL.Inventory_DB[Order][Depth, Before_X, Before_Y] = 0;
                    }
                    //Inventory_Library.IL.Inventory_DB[Order][4, (short)XLoc, (short)YLoc] =;
                    int NSize = 0;
                    if (Inventory_Library.IL.Inventory_DB[Order].GetLength(2) < 10)
                    {
                        NSize += 10 * Inventory_Library.IL.Inventory_DB[Order].GetLength(1);
                        NSize += Inventory_Library.IL.Inventory_DB[Order].GetLength(2);
                    }



                    foreach (Transform VisualArea in Inventory_Player_Shown.InvPS.Player_Storages)
                    {
                        switch (NSize)
                        {

                            case 86:
                                if (VisualArea.GetComponent<Inventory_8x6>().Storage_Order == Order)
                                {
                                    VisualArea.GetComponent<Inventory_8x6>().Refreshing_Changed_Slots(Inventory_Library.IL.Inventory_DB[Order]);
                                    Debug.Log("Size86 Checked, Refreshing Complete.");
                                }
                                break;
                        }
                    }
                }
                break;

            case PROTOCOL.FIRST_SYNC_REQ:
                {
                    Debug.Log("-------------------------");
                }
                break;
            case PROTOCOL.FIRST_SYNC_REQTOHOST:
                {
                    int Req_SN = msg.pop_int32();
                    int Host_SN = msg.pop_int32();
                    Debug.Log("Server Succesfully Respons FSR");
                    Debug.Log(playerSN + " " + Host_SN);
                    if (Host_SN == playerSN)
                    {
                        Debug.Log("requesting Arrival 0501");
                        Inventory_Library.IL.Syncronize_Packages_If_Host(Req_SN);
                    }
                }
                break;
            case PROTOCOL.PLAYER_ANIMATION:
                {
                    int player_index = msg.pop_int32();
                    string ANI_NAME = msg.pop_string();
                    int Bool = msg.pop_int32();
                    float Floatt = msg.pop_float();
                    int Setting = msg.pop_int32();

                    bool Tof;
                    if (Bool == 1)
                    {
                        Tof = true;
                    }
                    else
                    {
                        Tof = false;
                    }
                    NetObject Net = ServerObjectManager.current.FindObject(player_index);


                    foreach (player_animation anime in Net.gameObject.GetComponentsInChildren<player_animation>())
                    {
                        switch (Setting)
                        {
                            case 1:
                                anime.animatorsetBool(ANI_NAME, Tof);
                                break;
                        }
                    }

                }
                break;
            case PROTOCOL.PLAYER_ROTATION:
                {
                    int player_index = msg.pop_int32();
                    float x = msg.pop_float();
                    float y = msg.pop_float();
                    float z = msg.pop_float();
                    float w = msg.pop_float();

                    Quaternion TargetLocation = new Quaternion(x, y, z, w);

                    NetObject Net = ServerObjectManager.current.FindObject(player_index);
                    Net.gameObject.GetComponentInChildren<player_rot>().Recieveing_Rotation(TargetLocation);
                }
                break;
            case PROTOCOL.HOST_ZOM_SPAWN:
                {
                    int Zomdex = msg.pop_int32();
                    Debug.Log(Zomdex);
                    foreach (GameObject ZSP in Zombie_Spawn_Point)
                    {
                        ZSP.SetActive(true);
                        foreach (GameObject zombie_Name_Nav in ZSP.GetComponent<respawn_Controller>().zom_nav)
                        {
                            if (zombie_Name_Nav.activeSelf == false)
                            {
                                zombie_Name_Nav.gameObject.SetActive(true);
                                zombie_Name_Nav.GetComponent<zom_pos>().ZOM_SN = Zomdex;
                                return;
                            }
                        }
                    }
                }
                break;
        }
    }
}
