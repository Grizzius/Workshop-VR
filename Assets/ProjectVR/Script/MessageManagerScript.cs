using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManagerScript : MonoBehaviour
{
    public UIChatScript chatCanvas;
    public string[] startMessage;

    private void Start()
    {
        sendMultipleMessage(startMessage);
    }

    public void sendMultipleMessage(string[] texts)
    {
        Debug.Log("Sending multiple messages");
        StartCoroutine(WaitForMessage(3, texts));
    }

    public void sendPartnerMessage(string text)
    {

        Debug.Log("Sending a new message");
        chatCanvas.SendPartnerTextBox(text);
    }

    public void SendPlayerMessage(string text)
    {
        chatCanvas.SendPlayerTextBox(text);
    }

    IEnumerator WaitForMessage(float waitTime, string[] texts)
    {
        Debug.Log("Start message Coroutine");
        foreach (string text in texts)
        {
            yield return new WaitForSeconds(waitTime);
            sendPartnerMessage(text);
        }
    }
}
