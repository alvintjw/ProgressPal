using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    public TMP_InputField duration; // Use TMP_InputField for TextMeshPro input field

    private float currentTime;

    public void StartCountdown()
    {
        float inputDuration;
        if (float.TryParse(duration.text, out inputDuration))
        {
            StartCoroutine(Countdown(inputDuration));
        }
        else
        {
            Debug.LogError("Invalid duration input!");
        }
    }

    private IEnumerator Countdown(float duration)
    {
        currentTime = duration;

        while (currentTime > 0)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        timerText.text = "Time's up";
        timerText.color = Color.red;
    }
}


  






