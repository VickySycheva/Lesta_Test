using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;

    [Header("End Screen"), Space]
    [SerializeField] private Canvas endScreen;
    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private Button restartButton;

    public void Init(Character character, Action onRestart)
    {
        character.OnHealthUpdate += UpdateHealth;
        
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(() => onRestart.Invoke());

        endScreen.gameObject.SetActive(false);
        timeText.gameObject.SetActive(false);
    }

    public void ShowWinScreen(float gameTime)
    {
        endScreen.gameObject.SetActive(true);

        timeText.gameObject.SetActive(true);
        timeText.text = "Время: " + gameTime;
        endText.text = "Победа!";
    }

    public void ShowLoseScreen()
    {
        endScreen.gameObject.SetActive(true);

        endText.text = "Поражение!";
    }

    private void UpdateHealth(float health)
    {
        healthText.text = "Здоровье: " + health;
    }
}
