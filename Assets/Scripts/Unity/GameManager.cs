using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public float timeLeft = 70f;
    public int totalHostages = 2;

    [Header("Game State")]
    public int deliveredHostages = 0;
    public bool gameEnded = false;

    [Header("UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI resultText;

    void Start()
    {
        Time.timeScale = 1f;
        deliveredHostages = 0;
        gameEnded = false;

        if (resultText != null)
            resultText.text = "";

        UpdateUI();
    }

    void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            LoseGame();
        }

        UpdateUI();
    }

    public void HostageDelivered()
    {
        if (gameEnded) return;

        deliveredHostages++;

        if (deliveredHostages >= totalHostages)
        {
            WinGame();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);

        if (statusText != null)
            statusText.text = "Rescued: " + deliveredHostages + "/" + totalHostages;
    }

    void WinGame()
    {
        gameEnded = true;
        Time.timeScale = 0f;

        if (resultText != null)
            resultText.text = "YOU WIN!\nAll hostages rescued!";
    }

    void LoseGame()
    {
        gameEnded = true;
        Time.timeScale = 0f;

        if (resultText != null)
            resultText.text = "YOU LOSE!\nTime is over!";
    }
}