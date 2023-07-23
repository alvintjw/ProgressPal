using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasToggle : MonoBehaviour
{
    public Canvas maincanvas;
    private bool active = true;

    public void ToggleCanvases()
    {
        maincanvas.gameObject.SetActive(active);
        active = !active;
    }
}
