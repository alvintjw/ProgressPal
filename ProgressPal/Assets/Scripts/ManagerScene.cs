using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public void StartTask()
    {
        SceneManager.LoadScene(1);
    }

    public void EndTask()
    {
        SceneManager.LoadScene(0);
    }
}
