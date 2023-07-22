using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskPanel : MonoBehaviour
{
    public ListObject listObject;
    public TaskPanel taskPanel;
    public Button closeButton;
    public Button finishButton;
    public Button editButton;
    public ConfirmPanel confirmPanel;
    public EditPanel editPanel;

    public InputField[] editInputFields;


    // Start is called before the first frame update
    void Start()
    {
        editInputFields = editPanel.GetComponentsInChildren<InputField>();

        closeButton.onClick.AddListener(CloseTaskPanel);
        finishButton.onClick.AddListener(OpenConfirmPanel);
        editButton.onClick.AddListener(OpenEditPanel);

    }

    public void CloseTaskPanel()
    {
        gameObject.SetActive(false);
    }

    
    public void OpenConfirmPanel()
    {
        confirmPanel.setObject(listObject);
        confirmPanel.gameObject.SetActive(true);
    }

    public void OpenEditPanel()
    {
        editPanel.setObject(listObject);
        editPanel.gameObject.SetActive(true);

        editInputFields[0].text = listObject.taskPanelInfo[0].text;
        editInputFields[1].text = listObject.taskPanelInfo[1].text;
        editInputFields[2].text = listObject.taskPanelInfo[2].text;
        editInputFields[3].text = listObject.taskPanelInfo[3].text;        

    }

    public void setObject(ListObject x)
    {
        listObject = x;
    }
    
}
