using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextEffect : MonoBehaviour
{
    TMP_Text objText;
    public string newText;
    string normalText;

    private void Start()
    {
        objText = GetComponentInChildren<TMP_Text>();
        normalText = objText.text;
    }

    public void TextChange(bool isOn) 
    { 
        if (isOn) 
        { 
            objText.text = newText;
        }
        else
            objText.text = normalText;
    }
}
