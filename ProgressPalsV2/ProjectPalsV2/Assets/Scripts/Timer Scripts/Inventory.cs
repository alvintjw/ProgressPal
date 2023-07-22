using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryToolkit;
    public Button inventoryButton;

    private bool isInventoryActive = false;

    private void Start()
    {
        inventoryToolkit.SetActive(false); // Set inventory toolkit inactive initially
        inventoryButton.onClick.AddListener(ToggleInventoryToolkit); // Attach the button click listener
    }

    private void ToggleInventoryToolkit()
    {
        isInventoryActive = !isInventoryActive; // Toggle the active state

        inventoryToolkit.SetActive(isInventoryActive); // Set the active state of the inventory toolkit
    }
}
