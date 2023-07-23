using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCanvasToggle : MonoBehaviour
{
    public Canvas shopcanvas;
    private bool active = true;

    public void ToggleCanvases()
    {
        shopcanvas.gameObject.SetActive(active);
        active = !active;
    }
}
