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
    [SerializeField] private TMP_InputField durationInput;
    [SerializeField] private TextMeshProUGUI inputPromptText;  // Add a reference to the input prompt text
    public Button startButton;
    private bool Pause;

    private int remainingDurationInSeconds;  // Represents the remaining duration in seconds

    // Start is called before the first frame update
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
    }
    

    private void StartTimer()
    {
  
        int inputDuration;
        if (int.TryParse(durationInput.text, out inputDuration))
        {
            startButton.gameObject.SetActive(false);  // Destroy the start button GameObject
            durationInput.gameObject.SetActive(false);  // Destroy the duration input text GameObject
            inputPromptText.gameObject.SetActive(false);  // Destroy the input prompt text GameObject
            Begin(inputDuration);
        
        }
        else
        {
            Debug.LogError("Invalid input duration.");
        }
    }

    private void Begin(int minutes)
    {
        Debug.Log("Begin method called.");
        remainingDurationInSeconds = minutes * 60;  // Convert minutes to seconds
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {

        float initialDuration = remainingDurationInSeconds; 
        while (remainingDurationInSeconds > 0)
        {
            if (!Pause)
            {
                int minutes = remainingDurationInSeconds / 60;  // Get the minutes
                int seconds = remainingDurationInSeconds % 60;  // Get the seconds
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
        startButton.gameObject.SetActive(true);  // Destroy the start button GameObject
        durationInput.gameObject.SetActive(true);  // Destroy the duration input text GameObject
        inputPromptText.gameObject.SetActive(true);  // Destroy the input prompt text GameObject
    }
}