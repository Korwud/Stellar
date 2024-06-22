using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Unit1_Button : MonoBehaviour
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
        favorites = Unit1_Favorites.FavoriteClone;
        if (Unit1_Favorites.IsTurnOn)
        {
            var name = "Unit1_Card";
            for (var i = 0; i < Unit1_Favorites.QuestionCount; i++)
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
                else if (i == Unit1_Favorites.QuestionCount - 1)
                {
                    if (button.IsUnityNull())
                        SceneManager.LoadScene("Main-menu");
                    else
                        button.onClick.AddListener(delegate{SceneManager.LoadScene("Main-menu");});
                    Unit1_Favorites.TurnOff();
                    Unit1_Favorites.CloneFavorite();
                }    
            }
        }
    }


    public void LoadMistake()
    {
        var mistakes = Unit1_Favorites.MistakesClone;
        if (Unit1_Favorites.MistakeTurnOn)
        {
            var name = "Unit1_Card";
            for (var i = 0; i < Unit1_Favorites.QuestionCount; i++)
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
                else if (i == Unit1_Favorites.QuestionCount - 1)
                {
                    if (button.IsUnityNull())
                        SceneManager.LoadScene("Main-menu");
                    else
                        button.onClick.AddListener(delegate{SceneManager.LoadScene("Main-menu");});
                    Unit1_Favorites.MistakeTurnOn = false;
                }    
            }
        }
    }
}
