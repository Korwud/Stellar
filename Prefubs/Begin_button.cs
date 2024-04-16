using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Begin_button : MonoBehaviour
{
    public bool running_coroutine;

    void Update()
    {
        if (running_coroutine)
        {
            StartCoroutine(delay());
        }
    }

    public void Task()
    {
        running_coroutine = true;
    }

    private IEnumerator delay()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("Mode_select");
    }
}
