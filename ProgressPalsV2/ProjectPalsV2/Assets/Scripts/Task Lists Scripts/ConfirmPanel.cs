using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPanel : MonoBehaviour
{
    public TaskPanel taskPanel;
    public ConfirmPanel confirmPanel;
    public Button noButton;
    public Button yesButton;
    public ListObject toDelete;
    public ListManager listManager;

    // Start is called before the first frame update
    void Start()
    {
        noButton.onClick.AddListener(CloseConfirmPanel);
        yesButton.onClick.AddListener(ConfirmFinish);
    }

    // Update is called once per frame
    public void CloseConfirmPanel()
    {
        confirmPanel.gameObject.SetActive(false);
    }

    public void ConfirmFinish()
    {
        confirmPanel.gameObject.SetActive(false);
        taskPanel.gameObject.SetActive(false);
        listManager.listObjects.Remove(toDelete);
        Destroy(toDelete.gameObject);
    }

    public void setObject(ListObject x)
    {
        toDelete = x;
    }
}
