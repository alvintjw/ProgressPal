using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Timer : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Pause = !Pause;
    } 
    
    [SerializeField] private Image uiFill;
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private Slider durationSlider;
    //[SerializeField] private TextMeshProUGUI inputPromptText;
    public Button startButton;
    private bool Pause;

    private int remainingDurationInSeconds;

    void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartTimer);
        }
        else
        {
            Debug.LogError("Start Button not found in the scene.");
        }

        durationSlider.onValueChanged.AddListener(UpdateSliderText);
    }
    
    private void StartTimer()
    {
        float sliderValue = durationSlider.value;
        int inputDuration = Mathf.RoundToInt(sliderValue * 60);  // Convert slider value to minutes

        startButton.gameObject.SetActive(false);
        durationSlider.gameObject.SetActive(false);
        //inputPromptText.gameObject.SetActive(false);
        Begin(inputDuration);
    }

    private void Begin(int seconds)
    {
        Debug.Log("Begin method called.");
        remainingDurationInSeconds = seconds;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        float initialDuration = remainingDurationInSeconds;
        
        while (remainingDurationInSeconds > 0)
        {
            if (!Pause)
            {
                int minutes = remainingDurationInSeconds / 60;
                int seconds = remainingDurationInSeconds % 60;
                uiText.text = $"{minutes:00} : {seconds:00}";
                uiFill.fillAmount = Mathf.InverseLerp(0, initialDuration, remainingDurationInSeconds);
                remainingDurationInSeconds--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
        OnEnd();
    }

    private void OnEnd()
    {
        uiText.text = "Time's up";
        uiFill.fillAmount = 0f;
        uiText.color = Color.red;
        startButton.gameObject.SetActive(true);
        durationSlider.gameObject.SetActive(true);
        //inputPromptText.gameObject.SetActive(true);
    }
    
    private void UpdateSliderText(float value)
    {
        int totalSeconds = Mathf.RoundToInt(value * 60);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        uiText.text = $"{minutes:00}:{seconds:00}";
    }
}
