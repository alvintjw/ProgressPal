using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListManager : MonoBehaviour
{
    public Transform content;
    public GameObject addPanel;
    public Button createButton;
    public GameObject listItemPrefab;

    string filePath;

    private List<ListObject> listObjects = new List<ListObject>();

    private InputField addInputFields;

    private void Start()
    {
        filePath = Application.persistentDataPath + "/checklist.txt";
        addInputFields = addPanel.GetComponentInChildren<InputField>();

        createButton.onClick.AddListener(delegate {CreateListItem(addInputFields.text);});
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

    void CreateListItem(string name)
    {
        GameObject item = Instantiate(listItemPrefab);

        item.transform.SetParent(content);
        ListObject itemObject = item.GetComponent<ListObject>();
        int index = listObjects.Count;
        itemObject.SetObjectInfo(name, index);
        listObjects.Add(itemObject);
        ListObject temp = itemObject;
        itemObject.GetComponent<Toggle>().onValueChanged.AddListener(delegate {CheckItem(temp);});

        SwitchMode(0);
    }

    void CheckItem(ListObject item)
    {
        listObjects.Remove(item);
        Destroy(item.gameObject);
    }
    
}
