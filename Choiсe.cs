using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choiсe : MonoBehaviour
{
    private bool IsPressedRightButton;
    private bool IsPressedFirstWrongButton;
    private bool IsPressedSecondWrongButton;
    private bool IsPressedSendButton;
    public Button sendButton;
    public Button rightButton;
    public Button firstWrongButton;
    public Button secondWrongButton;

    void Update()
    {
        On_Click();
        if (IsPressedSendButton)
            ChangeColor();
    }

    public void On_Click()
    {
        rightButton.onClick.AddListener(delegate{
            Falsification();
            IsPressedRightButton = true;});
        firstWrongButton.onClick.AddListener(delegate{
            Falsification();
            IsPressedFirstWrongButton = true;});
        secondWrongButton.onClick.AddListener(delegate{
            Falsification();
            IsPressedSecondWrongButton = true;});
        sendButton.onClick.AddListener(delegate{IsPressedSendButton = true;});
    }

    public void Falsification()
    {
        IsPressedRightButton = false;
        IsPressedFirstWrongButton = false;
        IsPressedSecondWrongButton = false;
    }

    public void UnactiveButtons()
    {
        rightButton.GetComponent<Button>().interactable = false;
        firstWrongButton.GetComponent<Button>().interactable = false;
        secondWrongButton.GetComponent<Button>().interactable = false;
    }

    public void ChangeColor()
    {
        if (IsPressedRightButton)
            rightButton.GetComponent<Image>().color = Color.green;
        else if (IsPressedFirstWrongButton)
            firstWrongButton.GetComponent<Image>().color = Color.red;
        else if (IsPressedSecondWrongButton)
            secondWrongButton.GetComponent<Image>().color = Color.red;
        if (IsPressedRightButton || IsPressedFirstWrongButton || IsPressedSecondWrongButton)
            UnactiveButtons();
        IsPressedSendButton = false;
    }
}