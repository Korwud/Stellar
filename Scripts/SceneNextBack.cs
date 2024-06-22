using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesNextBack : MonoBehaviour
{
    public void SceneNext()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }

    public void ScenePrevious()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index - 1);
    }
}