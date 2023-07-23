using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchPanel : MonoBehaviour
{
    public InputField searchInput;
    public Transform searchContent;
    public Transform mainContent;
    public Button searchButton;
    public Button closeButton;
    public Button taskPanelCloseButton;
    public ListManager listManager;
    

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(CloseSearchPanel);
        
        searchButton.onClick.AddListener(delegate {SearchGroup(searchInput.text);});

        taskPanelCloseButton.onClick.AddListener(delegate {SearchGroup(searchInput.text);});
    }

    void CloseSearchPanel()
    {
        this.gameObject.SetActive(false);
        foreach (ListObject x in listManager.listObjects)
        {
            x.transform.SetParent(mainContent);
        }

        listManager.SortContent();
    }
    
    public void SearchGroup(string grp)
    {
        if (this.gameObject.activeSelf)
        {
            foreach (ListObject x in listManager.listObjects)
            {
                x.transform.SetParent(mainContent);
            }

            foreach (ListObject x in listManager.listObjects)
            {
                if (x.objGroup == searchInput.text)
               {
                  x.transform.SetParent(searchContent);
               }
            }
        }
    }
    
}
