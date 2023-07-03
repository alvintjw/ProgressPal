using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListManager : MonoBehaviour
{
    public Transform content;
    public GameObject addPanel;
    public Button addButton;
    public Button cancelButton;
    public GameObject listItemPrefab;

    public GameObject taskPanel;
    
    string filePath;

    private List<ListObject> listObjects = new List<ListObject>();

    private InputField[] addInputFields;

    public Button finishButton;

    private void Start()
    {
        filePath = Application.persistentDataPath + "/checklist.txt";
        addInputFields = addPanel.GetComponentsInChildren<InputField>();

        addButton.onClick.AddListener(delegate {CreateListItem(
            addInputFields[0].text, addInputFields[1].text, addInputFields[2].text);});
        
        cancelButton.onClick.AddListener(CloseAddPanel);
    }

    public void SwitchMode(int mode)
    {
        switch(mode)
        {
            case 0:
            addPanel.SetActive(false);
            break;

            case 1:
            addPanel.SetActive(true);
            break;
        }
    }



    void CreateListItem(string name, string date, string description)
    {
        GameObject item = Instantiate(listItemPrefab);

        item.transform.SetParent(content);
        ListObject itemObject = item.GetComponent<ListObject>();

        itemObject.taskPanel = taskPanel;
        itemObject.finishButton = finishButton;

        int index = listObjects.Count;
        itemObject.SetObjectInfo(name, date, description, index);
        listObjects.Add(itemObject);
        ListObject temp = itemObject;
        Debug.Log(temp);
        temp.finishButton.onClick.AddListener(delegate {CheckItem(temp);});

        SwitchMode(0);
    }

    void CloseAddPanel()
    {
        SwitchMode(0);
    }



    public void CheckItem(ListObject item)
    {
        listObjects.Remove(item);
        Destroy(item.gameObject);
        
    }

    
}