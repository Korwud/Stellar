using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextColor : MonoBehaviour
{
    public Text title;
    public Text content;
    public Button mainButton;
    public Button firstOtherButton;
    public Button secondOtherButton;

    private bool IsPressedMainButton;
    private bool IsPressedFirstOtherButton;
    private bool IsPressedSecondOtherButton;
    
    void Update()
    {
        On_Click();
        if (IsPressedMainButton)
            ChangeColor();
        else if (title.color != Color.white && !IsPressedMainButton)
        {
            title.GetComponent<Text>().color = Color.white;
            content.color = Color.white;
        }
    }


    public void On_Click()
    {
        mainButton.onClick.AddListener(delegate{
            Falsification();
            IsPressedMainButton = true;});
        firstOtherButton.onClick.AddListener(delegate{
            Falsification();
            IsPressedFirstOtherButton = true;});
        secondOtherButton.onClick.AddListener(delegate{
            Falsification();
            IsPressedSecondOtherButton = true;});
    }

    public void Falsification()
    {
        IsPressedMainButton = false;
        IsPressedFirstOtherButton = false;
        IsPressedSecondOtherButton = false;
    }
    void ChangeColor()
    {
        title.GetComponent<Text>().color = Color.cyan;
        content.color = Color.cyan;
    }
}
