using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatText : MonoBehaviour
{
    public void OnCreateText(string msg)
    {
        UnityEngine.UI.Text text= GetComponentInChildren<UnityEngine.UI.Text>();
        if (text != null)
            text.text = msg;

    }
}
