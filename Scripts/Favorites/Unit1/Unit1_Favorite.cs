using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Unit1_Favorites : MonoBehaviour
{
    public const int QuestionCount = 10;

    public static bool[] IsFavoriteUnit1 = new bool[QuestionCount];
    public static bool[] FavoriteClone = new bool[QuestionCount];
    
    public TextMeshProUGUI favorite;
    public Button button;
    public int numberCard;
    public static bool IsTurnOn = false;
    public static bool IsInitialized = false;

    void Start()
    {
        var count = 0;
        foreach (var i in IsFavoriteUnit1)
        {
            if (i)
                count++;
        }
        favorite.text = $"Избранное: {count}";
    }

    public void Update()
    {
        if (button is not null)
        {
            if (IsFavoriteUnit1[numberCard - 1])
                button.gameObject.SetActive(true);
            else
                button.gameObject.SetActive(false);
        }

        var count = 0;
        foreach (var i in IsMistakeUnit1)
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
        IsFavoriteUnit1[numberCard - 1] = true;
        FavoriteClone[numberCard - 1] = true;
    }

    public void FromFavorite()
    {
        IsFavoriteUnit1[numberCard - 1] = false;
        FavoriteClone[numberCard - 1] = false;
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
        FavoriteClone = (bool[])IsFavoriteUnit1.Clone();
    }



    public static bool[] IsMistakeUnit1 = new bool[QuestionCount];
    public static bool[] MistakesClone = new bool[QuestionCount];
    public static bool MistakeTurnOn = false;
    public TextMeshProUGUI mistakes;

    public static void ChangeMistakes(int numberCard, bool value)
    {
        IsMistakeUnit1[numberCard - 1] = value;
    }

    public void MistakeOn()
    {
        MistakeTurnOn = true;
        MistakesClone = (bool[])IsMistakeUnit1.Clone();
    }
}
