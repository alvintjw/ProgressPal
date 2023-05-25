using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private TMP_InputField durationInput;
    [SerializeField] private TextMeshProUGUI inputPromptText;  // Add a reference to the input prompt text
    private Button startButton;

    private int remainingDurationInSeconds;  // Represents the remaining duration in seconds

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start method called.");
        startButton = FindObjectOfType<Button>();
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
        Debug.Log("StartTimer method called.");
        int inputDuration;
        if (int.TryParse(durationInput.text, out inputDuration))
        {
            Destroy(startButton.gameObject);  // Destroy the start button GameObject
            Destroy(durationInput.gameObject);  // Destroy the duration input text GameObject
            Destroy(inputPromptText.gameObject);  // Destroy the input prompt text GameObject
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
         Debug.Log("UpdateTimer method called.");
        while (remainingDurationInSeconds > 0)
        {
            int minutes = remainingDurationInSeconds / 60;  // Get the minutes
            int seconds = remainingDurationInSeconds % 60;  // Get the seconds

            uiText.text = $"{minutes:00} : {seconds:00}";
            uiFill.fillAmount = Mathf.InverseLerp(0, remainingDurationInSeconds, remainingDurationInSeconds);

            remainingDurationInSeconds--;
            yield return new WaitForSeconds(1f);
        }

        uiText.text = "Time's up";
        uiFill.fillAmount = 0f;
        uiText.color = Color.red;
    }
}
