using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private TextMeshProUGUI uiText;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener((v) => {
            uiText.text = v.ToString("0");
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
