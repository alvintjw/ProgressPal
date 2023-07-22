using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasklistToggle : MonoBehaviour
{
    public Canvas tasklistcanvas;
    private bool active = true;

    public void ToggleCanvases()
    {
        tasklistcanvas.gameObject.SetActive(active);
        active = !active;
    }
}
