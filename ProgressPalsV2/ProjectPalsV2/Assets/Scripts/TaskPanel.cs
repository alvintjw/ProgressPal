using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskPanel : MonoBehaviour
{
    public GameObject taskPanel;
    public GameObject listItem;
    public Button closeButton;
    public Button finishButton;
    public GameObject confirmPanel;

    //public TMP_Text taskPanelName;

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(CloseTaskPanel);
        finishButton.onClick.AddListener(OpenConfirmPanel);
        
    }


    public void CloseTaskPanel()
    {
        taskPanel.SetActive(false);
    }

    
    public void OpenConfirmPanel()
    {
        confirmPanel.SetActive(true);
    }
    
}
