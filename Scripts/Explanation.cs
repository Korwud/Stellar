using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Explanation : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string explanation;
    public float fontSize;

    private string question;
    private float oldFontSize;
    private bool flag = false;


    public void ChangeText()
    {
        if (!flag)
            SaveTextSettings();
        if (text.text == explanation)
        {
            text.text = question;
            text.fontSize = oldFontSize;
            text.fontStyle = FontStyles.Bold;
        }
        else
        {
            text.text = explanation;
            text.fontSize = fontSize;
            text.fontStyle = FontStyles.Normal;
        }
    }

    void SaveTextSettings()
    {
        question = text.text;
        oldFontSize = text.fontSize;
        flag = true;
    }
}
