﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //config parameters
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int scorePerBlocksDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoplayEnabled;

    //states
    int currentScore = 0;

    public int CurrentScore
    { 
        get { return currentScore;}
        set {currentScore = value;}
    }

    //Singleton Pattern to have only one GameStatus object during the whole game 
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = CurrentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        CurrentScore += scorePerBlocksDestroyed;
        scoreText.text = CurrentScore.ToString();
    }

    public void ResetScore()
    {
        Destroy(gameObject);
    }

    public bool IsAutoplayEnabled()
    {
        return isAutoplayEnabled;
    }
}
