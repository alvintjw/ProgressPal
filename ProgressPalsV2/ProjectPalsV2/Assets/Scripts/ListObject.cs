using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ListObject : MonoBehaviour
{

    public static int count;
    public string objName;
    public string objDate;
    public string objDescription;
    public string objGroup;
    public int index;

    public TMP_Text itemName;
    public TMP_Text itemDate;
    //public TMP_Text itemIndex;
    private Button button;
    public TaskPanel taskPanel;
    public TMP_Text[] taskPanelInfo;
    
    public Button finishButton;
    
    public GameObject confirmPanel;

    private void Start() 
    {
        taskPanelInfo = taskPanel.GetComponentsInChildren<TMP_Text>();
        itemName.text = objName;
        itemDate.text = objDate;

        index = count;
        ++ count;
        //itemIndex.text = index.ToString();
        button = GetComponent<Button>();
        button.onClick.AddListener(OpenTaskPanel);
    }

    public void SetObjectInfo(string name, string date, string description, string group)
    {
        this.objName = name;
        this.objDate = date;
        this.objDescription = description;
        this.objGroup = group;
    }

    public void OpenTaskPanel()
    {
        taskPanel.setObject(this);
        taskPanelInfo[0].text = objName;
        taskPanelInfo[1].text = objDate;
        taskPanelInfo[2].text = objDescription;
        taskPanelInfo[3].text = objGroup;
        taskPanel.gameObject.SetActive(true);
        
    }

    
}
