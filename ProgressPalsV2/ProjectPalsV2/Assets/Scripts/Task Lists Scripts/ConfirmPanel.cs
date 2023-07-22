using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPanel : MonoBehaviour
{
    public GameObject taskPanel;
    public GameObject confirmPanel;
    public Button noButton;
    public Button yesButton;

    // Start is called before the first frame update
    void Start()
    {
        noButton.onClick.AddListener(CloseConfirmPanel);
        yesButton.onClick.AddListener(ConfirmFinish);
    }

    // Update is called once per frame
    public void CloseConfirmPanel()
    {
        confirmPanel.SetActive(false);
    }

    public void ConfirmFinish()
    {
        confirmPanel.SetActive(false);
        taskPanel.SetActive(false);
    }
}
