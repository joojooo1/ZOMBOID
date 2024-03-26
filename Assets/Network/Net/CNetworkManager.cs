using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FreeNetUnity;
using FreeNet;
public class CNetworkManager : MonoBehaviour
{
    CFreeNetUnityService gameserver;
    [SerializeField]
    MonoBehaviour message_receiver;
    void Awake()
    {
        this.gameserver = gameObject.AddComponent<CFreeNetUnityService>();
        this.gameserver.appcallback_on_status_changed += on_Status_changed;
        this.gameserver.appcallback_on_message += on_message;
    }
    public void Connect()
    {
        if (netstatus == NETWORK_EVENT.disconnected)
        {
            this.gameserver.connect("127.0.0.1", 7979);
            Debug.Log("Connection Tryed");
        }

    }

    void on_message(CPacket msg)
    {
        message_receiver.SendMessage("on_recv", msg);
    }

    public void send(CPacket msg)
    {
        this.gameserver.send(msg);
    }

    NETWORK_EVENT netstatus = NETWORK_EVENT.disconnected;
    //네트워크 연결 상태 변경시 호출 되는 함수
    void on_Status_changed(NETWORK_EVENT status)
    {
        netstatus = status;
        switch (status)
        {
            case NETWORK_EVENT.connected:
                {
                    Debug.Log("On Connected");
                }
                break;
            case NETWORK_EVENT.disconnected:
                {
                    Debug.Log("disconnected");
                }
                break;
        }
    }

}
