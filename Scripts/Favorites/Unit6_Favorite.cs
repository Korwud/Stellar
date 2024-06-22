using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Unit6_Favorites : MonoBehaviour
{
    public const int QuestionCount = 6;

    public static bool[] IsFavoriteUnit6 = new bool[QuestionCount];
    public static bool[] Clone = new bool[QuestionCount];

    public TextMeshProUGUI favorite;
    public Button button;
    public int numberCard;
    public static bool IsTurnOn = false;
    public static bool IsInitialized = false;

    void Start()
    {
        var count = 0;
        foreach (var i in IsFavoriteUnit6)
        {
            if (i is true)
                count++;
        }
        favorite.text = $"Избранное: {count}";
    }

    public void Update()
    {
        if (button is not null)
        {
            if (IsFavoriteUnit6[numberCard - 1])
                button.gameObject.SetActive(true);
            else
                button.gameObject.SetActive(false);
        }

        var count = 0;
        foreach (var i in IsMistakeUnit2)
        {
            if (!i)
                count++;
        }
        if (count == QuestionCount)
            count = 0;
        mistakes.text = $"Ошибок: {count}";
    }

    public void ToFavorite()
    {
        IsFavoriteUnit6[numberCard - 1] = true;
        Clone[numberCard - 1] = true;
    }

    public void FromFavorite()
    {
        IsFavoriteUnit6[numberCard - 1] = false;
        Clone[numberCard - 1] = false;
    }

    public void TurnOn()
    {
        IsTurnOn = true;
    }

    public static void TurnOff()
    {
        IsTurnOn = false;
    }

    public static void CloneFavorite()
    {
        Clone = (bool[])IsFavoriteUnit6.Clone();
    }


    public static bool[] IsMistakeUnit2 = new bool[QuestionCount];
    public static bool[] MistakesClone = new bool[QuestionCount];
    public static bool MistakeTurnOn = false;
    public TextMeshProUGUI mistakes;

    public static void ChangeMistakes(int numberCard, bool value)
    {
        IsMistakeUnit2[numberCard - 1] = value;
    }

    public void MistakeOn()
    {
        MistakeTurnOn = true;
        MistakesClone = (bool[])IsMistakeUnit2.Clone();
    }
}
