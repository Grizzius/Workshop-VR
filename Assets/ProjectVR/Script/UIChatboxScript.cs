using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChatboxScript : MonoBehaviour
{
    public string textBoxText;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = textBoxText;
    }
}
