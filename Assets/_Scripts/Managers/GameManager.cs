using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Coins { get; set; } = 0;
    public int Score { get; set; } = 0;
    public int coinTotal { get; set; } = 0;

    [Header("UI References")]
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI coinText;
    private TextMeshProUGUI healthText;

    private Transform canvas;
    public Transform coins { get; private set; }
    private PlayerController player;

    public List<GameObject> UIs = new List<GameObject>();

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

    }

    private void Start()
    {
        // Tìm Canvas
        canvas = GameObject.Find("Canvas")?.transform;
        if (canvas != null)
        {
            foreach (Transform child in canvas)
            {
                UIs.Add(child.gameObject);
            }
        }

        // Tìm Player
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.GetComponent<PlayerController>();
        }

        // Tìm Coins
        coins = GameObject.Find("Coins")?.transform;
        coinTotal = coins?.childCount ?? 0;

        // Tìm các UI Text
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        coinText = GameObject.Find("CoinText")?.GetComponent<TextMeshProUGUI>();
        healthText = GameObject.Find("HealthText")?.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        UpdateScoreAndCoinText();
    }

    private void UpdateScoreAndCoinText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + Score;

        if (coinText != null)
            coinText.text = "Coins: " + Coins + "/" + coinTotal;

        if (healthText != null && player != null)
            healthText.text = "Health: " + player.health;
    }
}
