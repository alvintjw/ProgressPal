using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    public InputField inputName;
    public InputField inputDate;
    public InputField inputDescription;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(Clear);
    }

    public void Clear()
    {
        inputName.text = "";
        inputDate.text = "";
        inputDescription.text = "";
    }
}
