using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;


public class SceneRandom : MonoBehaviour
{
    private static int sceneNumber = 0;
    public static bool RandomTurnOn = false;
    public Button button;

    void Start()
    {
    
    }
    public void SceneChange()
    {
        if (RandomTurnOn)
        {
            var sceneName = GetScene();
            if (sceneNumber != 9)
            {
                sceneNumber++;
                if (button.IsUnityNull())
                    SceneManager.LoadScene(sceneName);
                else
                    button.onClick.AddListener(delegate{SceneManager.LoadScene(sceneName);});
            }
            else
            {
                RandomTurnOn = false;
                sceneNumber = 0;
            } 
        }
    }

    private static string GetScene()
    {
        var random = new System.Random();
        var unitNumber = random.Next(1, 14);
        var number = random.Next(1, 10);
        var sceneName = $"Unit{unitNumber}_Card{number}";
        var scene = SceneManager.GetSceneByName(sceneName);
        while (scene.IsUnityNull())
        {
            number--;
            sceneName = $"Unit{unitNumber}_Card{number}";
            scene = SceneManager.GetSceneByName(sceneName);
        }
        return sceneName;
    }

    public void RandomTurn()
    {
        RandomTurnOn = true;
    }
}