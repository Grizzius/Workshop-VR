using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChatScript : MonoBehaviour
{
    [SerializeField] Canvas ChatCanvas;
    [SerializeField] Scrollbar scrollBar;
    [SerializeField] GameObject partnerTextBox;
    [SerializeField] GameObject playerTextBox;
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        setScrollValueToZero();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setScrollValueToZero()
    {
        scrollBar.value = 0;
    }


    public void SendPartnerTextBox(string text)
    {
        var newPartnerTextBox = Instantiate(partnerTextBox, ChatCanvas.transform) ;
        UIChatboxScript chatBoxScript = newPartnerTextBox.GetComponent<UIChatboxScript>();
        chatBoxScript.textBoxText = text;
        setScrollValueToZero();
        audioSource.Play();

    }
    public void SendPlayerTextBox(string text)
    {
        var newPlayerTextBox = Instantiate(playerTextBox, ChatCanvas.transform);
        UIChatboxScript chatBoxScript = newPlayerTextBox.GetComponent<UIChatboxScript>();
        chatBoxScript.textBoxText = text;
        setScrollValueToZero();
    }
}
