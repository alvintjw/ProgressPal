using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListManager : MonoBehaviour
{
    public static ListManager Instance { get; private set; }

    public Transform mainContent;
    public GameObject addPanel;
    public Button addButton;
    public Button cancelButton;
    public GameObject listItemPrefab;

    public TaskPanel taskPanel;
    public SearchPanel searchPanel;
    
    string filePath;

    //public List<ListObject> listObjects = new List<ListObject>();
    public List<ListObject> listObjects { get; private set; }


    private InputField[] addInputFields;

    public Button finishButton;
    public Button groupButton;

    private void Start()
    {
        if (listObjects == null)
        {
            listObjects = new List<ListObject>();
        }
        
        filePath = Application.persistentDataPath + "/checklist.txt";
        addInputFields = addPanel.GetComponentsInChildren<InputField>();

        addButton.onClick.AddListener(delegate {CreateListItem(
            addInputFields[0].text, addInputFields[1].text,
            addInputFields[2].text, addInputFields[3].text);});
        
        cancelButton.onClick.AddListener(CloseAddPanel);

        groupButton.onClick.AddListener(OpenSearchPanel);

        
    }

    private void Awake()
    {
        // Ensure there's only one instance of ListManager in the scene.
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(this.gameObject);
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



    void CreateListItem(string name, string date, string description, string group)
    {
        GameObject item = Instantiate(listItemPrefab);

        item.transform.SetParent(mainContent);
        ListObject itemObject = item.GetComponent<ListObject>();

        itemObject.taskPanel = taskPanel;
        itemObject.finishButton = finishButton;
        
        itemObject.SetObjectInfo(name, date, description, group);
        listObjects.Add(itemObject);

        addPanel.SetActive(false);
    }


/*
    public void CheckItem(int toDelete)
    {
        ListObject temp = listObjects[0];
        foreach (ListObject x in listObjects)
        {
            if (x.index == toDelete)
            {
                temp = x;
            } 
        }
        listObjects.Remove(temp);
        Destroy(temp.gameObject);
    }
*/
    public void CloseAddPanel()
    {
        addPanel.SetActive(false);
    }

    public void OpenSearchPanel()
    {
        searchPanel.gameObject.SetActive(true);
    }
    

    public void SortContent()
    {
        listObjects.Sort((a, b) => a.index.CompareTo(b.index));
        foreach (ListObject x in listObjects)
        {
            x.transform.SetAsLastSibling();
        }
    }
}