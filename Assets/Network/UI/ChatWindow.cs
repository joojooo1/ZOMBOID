using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChatWindow : MonoBehaviour
{
    public static ChatWindow current;
    void Awake()
    {
        if (current == null)
            current = this;
        else
            UnityEngine.Debug.LogError("not single ChatWindow");
    }
    [SerializeField]
    GameObject ChatPrefab;

    [SerializeField]
    Transform chatpar;
    public void ChatCreate(string msg)
    {
        GameObject obj = Instantiate(ChatPrefab, chatpar);
        obj.GetComponent<ChatText>().OnCreateText(msg);
    }
}
