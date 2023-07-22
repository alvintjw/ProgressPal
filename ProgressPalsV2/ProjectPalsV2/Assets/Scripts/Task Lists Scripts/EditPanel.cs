using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditPanel : MonoBehaviour
{
    public ListObject listObject;
    public Button confirmEditButton;
    public Button closeButton;
    public TaskPanel taskPanel;
    private TMP_Text[] taskPanelInfo;

    public InputField[] editInputFields;

    public SearchPanel searchPanel;

    // Start is called before the first frame update
    void Start()
    {
        editInputFields = this.GetComponentsInChildren<InputField>();
        taskPanelInfo = taskPanel.GetComponentsInChildren<TMP_Text>();

        

        confirmEditButton.onClick.AddListener(delegate {confirmEdit(
            editInputFields[0].text, editInputFields[1].text,
            editInputFields[2].text, editInputFields[3].text);});
            
        closeButton.onClick.AddListener(CloseEditPanel);
    }

    public void setObject(ListObject x)
    {
        listObject = x;
    }

    public void CloseEditPanel()
    {
        this.gameObject.SetActive(false);

    }

    public void confirmEdit(string name, string date, string desc, string group)
    {
        listObject.SetObjectInfo(name, date, desc, group);
        this.gameObject.SetActive(false);
        listObject.itemName.text = name;
        listObject.itemDate.text = date;

        
        taskPanel.setObject(listObject);
        taskPanelInfo[0].text = name;
        taskPanelInfo[1].text = date;
        taskPanelInfo[2].text = desc;
        taskPanelInfo[3].text = group;
    }
    
    
}
