using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text ballAmountText, scoreText;
    public GameObject gameOverPanel;

    void Awake()
    {
        instance = this;    
    }
    public void ShowGameOverPanel(bool on)
    {
        gameOverPanel.SetActive(on);
    }
    public void UpdateBallText(int amount)
    {
        ballAmountText.text = "Balls: " + amount;
    }
    public void UpdateScoreText(int amount)
    {
        scoreText.text = amount.ToString("D10");
    }
}
