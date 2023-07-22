using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    public InputField inputName;
    public InputField inputDate;
    public InputField inputDescription;
    public InputField inputGroup;
    public Button addTaskButton;

    public Button groupButton;
    public InputField groupInput;

    // Start is called before the first frame update
    void Start()
    {
        addTaskButton.onClick.AddListener(ClearAdd);
        groupButton.onClick.AddListener(ClearSearch);
    }

    public void ClearAdd()
    {
        inputName.text = "";
        inputDate.text = "";
        inputDescription.text = "";
        inputGroup.text = "";
    }

    public void ClearSearch()
    {
        groupInput.text = "";
    }
}
