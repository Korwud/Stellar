using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Unit2_Button : MonoBehaviour
{
    public static bool[] favorites;
    public Button button;
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void LoadFavorite()
    {
        favorites = Unit2_Favorites.Clone;
        if (Unit2_Favorites.IsTurnOn)
        {
            var name = "Unit2_Card";
            for (var i = 0; i < Unit2_Favorites.QuestionCount; i++)
            {
                if (favorites[i])
                {
                    favorites[i] = false;
                    var surname = name + (i + 1).ToString();
                    if (button.IsUnityNull())
                        SceneManager.LoadScene(surname);
                    else
                        button.onClick.AddListener(delegate{SceneManager.LoadScene(surname);});
                    break;
                }
                else if (i == Unit2_Favorites.QuestionCount - 1)
                {
                    if (button.IsUnityNull())
                        SceneManager.LoadScene("Main-menu");
                    else
                        button.onClick.AddListener(delegate{SceneManager.LoadScene("Main-menu");});
                    Unit2_Favorites.TurnOff();
                    Unit2_Favorites.CloneFavorite();
                } 
            }
        }
    }

    public void LoadMistake()
    {
        var mistakes = Unit2_Favorites.MistakesClone;
        if (Unit2_Favorites.MistakeTurnOn)
        {
            var name = "Unit2_Card";
            for (var i = 0; i < Unit2_Favorites.QuestionCount; i++)
            {
                if (!mistakes[i])
                {
                    mistakes[i] = true;
                    var surname = name + (i + 1).ToString();
                    if (button.IsUnityNull())
                        SceneManager.LoadScene(surname);
                    else
                        button.onClick.AddListener(delegate{SceneManager.LoadScene(surname);});
                    break;
                }
                else if (i == Unit2_Favorites.QuestionCount - 1)
                {
                    if (button.IsUnityNull())
                        SceneManager.LoadScene("Main-menu");
                    else
                        button.onClick.AddListener(delegate{SceneManager.LoadScene("Main-menu");});
                    Unit2_Favorites.MistakeTurnOn = false;
                }    
            }
        }
    }
}
