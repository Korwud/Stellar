using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneSelectName : MonoBehaviour
{
    public string sceneName;
    private bool running_coroutine;

    public void OpenScene()
    {
        if (!running_coroutine)
        {
            StartCoroutine(delay());
        }          
    }

    private IEnumerator delay()
    {
        running_coroutine = true;
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(sceneName);
    }
}