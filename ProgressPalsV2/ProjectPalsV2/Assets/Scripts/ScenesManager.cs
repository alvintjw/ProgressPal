using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void TimerPageButton()
    {
        SceneManager.LoadScene(1);
    }

    public void HomePageButton()
    {
        SceneManager.LoadScene(0);
    }

    public void TaskPageButton()
    {
        SceneManager.LoadScene(2);
    }
}
