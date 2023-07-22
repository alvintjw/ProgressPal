using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Timer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image uiFill;
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private Slider durationSlider;
    public Button startButton;

    private ShopManager shopManager;

    private bool isTimerRunning;
    private bool isPaused;
    private int remainingDurationInSeconds;

    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
        if (startButton != null)
        {
            startButton.onClick.AddListener(ToggleTimer);
        }
        else
        {
            Debug.LogError("Start Button not found in the scene.");
        }

        durationSlider.onValueChanged.AddListener(UpdateSliderText);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isTimerRunning)
        {
            TogglePause();
        }
    }

    private void ToggleTimer()
    {
        if (isTimerRunning)
        {
            StopTimer();
        }
        else
        {
            StartTimer();
        }
    }

    private void StartTimer()
    {
        float sliderValue = durationSlider.value;
        int inputDuration = Mathf.RoundToInt(sliderValue * 60);  // Convert slider value to minutes

        isTimerRunning = true;
        startButton.GetComponentInChildren<TextMeshProUGUI>().text = "Stop Timer";
        durationSlider.gameObject.SetActive(false);
        Debug.Log("Start timer");

        Begin(inputDuration);
    }

    private void StopTimer()
    {
        isTimerRunning = false;
        isPaused = false;
        startButton.GetComponentInChildren<TextMeshProUGUI>().text = "Start Timer";
        durationSlider.gameObject.SetActive(true);
        ResetUI();
        StopAllCoroutines();
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            startButton.GetComponentInChildren<TextMeshProUGUI>().text = "Stop Timer";
        }
        else
        {
            startButton.GetComponentInChildren<TextMeshProUGUI>().text = "Stop Timer";
        }
    }

    private void ResetUI()
    {
        uiText.text = "00:00";
        uiFill.fillAmount = 0f;
        uiText.color = Color.white;
    }

    private void Begin(int seconds)
    {
        remainingDurationInSeconds = seconds;
        Debug.Log("Begin");
   

        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        Debug.Log("Update timer");
        float initialDuration = remainingDurationInSeconds;

        while (remainingDurationInSeconds > 0)
        {
            if (isTimerRunning && !isPaused)
            {
                int minutes = remainingDurationInSeconds / 60;
                int seconds = remainingDurationInSeconds % 60;
                uiText.text = $"{minutes:00}:{seconds:00}";
                uiFill.fillAmount = Mathf.InverseLerp(0, initialDuration, remainingDurationInSeconds);
                remainingDurationInSeconds--;
            }
            yield return new WaitForSeconds(1f);
        }
        

        OnEnd();
    }

    private void OnEnd()
    {
        isTimerRunning = false;
        startButton.GetComponentInChildren<TextMeshProUGUI>().text = "Start Timer";

        uiText.text = "Time's up";
        uiFill.fillAmount = 0f;
        uiText.color = Color.red;
        durationSlider.gameObject.SetActive(true);
        
        /*
        if (shopManager != null)
        {
            shopManager.coins += 10; // Access the coins variable and increment it
            shopManager.UpdateCoinUI(); // Call a function in the ShopManager script to update the UI
        }
        */
        StopAllCoroutines();

    }

    private void UpdateSliderText(float value)
    {
        int totalSeconds = Mathf.RoundToInt(value * 60);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        uiText.text = $"{minutes:00}:{seconds:00}";
    }
}
