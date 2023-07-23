using UnityEngine;
using UnityEngine.UI;

public class CanvasToggle : MonoBehaviour
{
    public Canvas canvasToActivate;
    public Canvas canvasToDeactivate;
    private bool active = true;

    public void ToggleCanvases()
    {
        canvasToActivate.gameObject.SetActive(active);
        canvasToDeactivate.gameObject.SetActive(!active);
        active = !active;
    }
}
