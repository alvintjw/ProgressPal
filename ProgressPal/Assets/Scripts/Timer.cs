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
    private Button startButton;

    public int DurationInMinutes;  // Represents the duration in minutes

    private int remainingDurationInSeconds;  // Represents the remaining duration in seconds

    // Start is called before the first frame update
    void Start()
    {
        startButton = FindObjectOfType<Button>();
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartTimer);
        }
        else
        {
            Debug.LogError("Start Button not found in the scene.");
        }
        Begin(DurationInMinutes);
    }
    
    private void StartTimer()
    {
        int inputDuration;
        if (int.TryParse(durationInput.text, out inputDuration))
        {
            Begin(inputDuration);
        }
        else
        {
            Debug.LogError("Invalid input duration.");
        }
    }

    private void Begin(int minutes)
    {
        remainingDurationInSeconds = minutes * 60;  // Convert minutes to seconds
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDurationInSeconds >= 0)
        {
            int minutes = remainingDurationInSeconds / 60;  // Get the minutes
            int seconds = remainingDurationInSeconds % 60;  // Get the seconds

            uiText.text = $"{minutes:00} : {seconds:00}";
            uiFill.fillAmount = Mathf.InverseLerp(0, DurationInMinutes * 60, remainingDurationInSeconds);

            remainingDurationInSeconds--;
            yield return new WaitForSeconds(1f);
        }

        uiText.text = "Time's up";
        uiFill.fillAmount = 0f;
        uiText.color = Color.red;
    }
}

