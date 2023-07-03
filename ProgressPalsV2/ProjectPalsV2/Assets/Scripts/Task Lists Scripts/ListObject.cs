using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ListObject : MonoBehaviour
{
    public string objName;
    public string objDate;
    public string objDescription;
    public int index;

    public TMP_Text itemName;
    public TMP_Text itemDate;
    private Button button;
    public GameObject taskPanel;
    private TMP_Text[] taskPanelInfo;
    
    public Button finishButton;
    
    public GameObject confirmPanel;

    private void Start() 
    {
        taskPanelInfo = taskPanel.GetComponentsInChildren<TMP_Text>();
        itemName.text = objName;
        itemDate.text = objDate;
        button = GetComponent<Button>();
        button.onClick.AddListener(OpenTaskPanel);
        
    }

    public void SetObjectInfo(string name, string date, string description, int index)
    {
        this.objName = name;
        this.objDate = date;
        this.objDescription = description;
        this.index = index;
    }

    public void OpenTaskPanel()
    {
        taskPanelInfo[0].text = objName;
        taskPanelInfo[1].text = objDate;
        taskPanelInfo[2].text = objDescription;
        taskPanel.SetActive(true);
        
    }

    
}
