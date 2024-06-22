using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeButtonsColor : MonoBehaviour
{
    public string sceneName;
    public Button sendButton;
    public Button rightButton;
    public Button firstWrongButton;
    public Button secondWrongButton;
    public Button question;

    private bool IsPressedRightButton;
    private bool IsPressedFirstWrongButton;
    private bool IsPressedSecondWrongButton;
    private bool IsPressedSendButton;

    private bool IsColorChanged;

    public Sprite greenButton;
    public Sprite redButton;
    public Sprite newSendButton;

    void Update()
    {
        if (!IsColorChanged)
        {
            On_Click();
            if (IsPressedSendButton)
            {
                ChangeButtonColor();
                question.GetComponent<Button>().interactable = true;
            }

        }
        else
        {
            if (SceneRandom.RandomTurnOn)
                sendButton.onClick.AddListener(delegate{
                    var random = new SceneRandom();
                    random.SceneChange();});
            else
                sendButton.onClick.AddListener(delegate{SceneManager.LoadScene(sceneName);});
        } 
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

    public void ChangeButtonColor()
    {
        if (IsPressedRightButton)
        {
            rightButton.GetComponent<Image>().sprite = greenButton;
            Mistakes(true);
        }
        else if (IsPressedFirstWrongButton)
        {
            firstWrongButton.GetComponent<Image>().sprite = redButton;
            Mistakes(false);
        }
        else if (IsPressedSecondWrongButton)
        {
            secondWrongButton.GetComponent<Image>().sprite = redButton;
            Mistakes(false);
        }
        IsPressedSendButton = false;
        sendButton.GetComponent<Image>().sprite = newSendButton;
        IsColorChanged = true;
    }

    private void Mistakes(bool value)
    {
        var scene = SceneManager.GetActiveScene().name.Split('_');
        var activeNumber = int.Parse(scene[0].Substring(4));
        var numberCard = int.Parse(scene[1].Substring(4));
        switch (activeNumber)
        {
            case 1:
                Unit1_Favorites.ChangeMistakes(numberCard, value);
                break;
            case 2:
                Unit2_Favorites.ChangeMistakes(numberCard, value);
                break;
            case 3:
                Unit3_Favorites.ChangeMistakes(numberCard, value);
                break;
            case 4:
                Unit4_Favorites.ChangeMistakes(numberCard, value);
                break;
            case 5:
                Unit5_Favorites.ChangeMistakes(numberCard, value);
                break;
            case 6:
                Unit6_Favorites.ChangeMistakes(numberCard, value);
                break;
            case 7:
                Unit7_Favorites.ChangeMistakes(numberCard, value);
                break;
            case 8:
                Unit8_Favorites.ChangeMistakes(numberCard, value);
                break;
            case 9:
                Unit9_Favorites.ChangeMistakes(numberCard, value);
                break;
            case 10:
                Unit10_Favorites.ChangeMistakes(numberCard, value);
                break;
            case 11:
                Unit11_Favorites.ChangeMistakes(numberCard, value);
                break;
            case 12:
                Unit12_Favorites.ChangeMistakes(numberCard, value);
                break;
            case 13:
                Unit13_Favorites.ChangeMistakes(numberCard, value);
                break;
            case 14:
                Unit14_Favorites.ChangeMistakes(numberCard, value);
                break;
        }
    }
}