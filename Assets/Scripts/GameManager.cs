using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum GameStatus
{
    Start,
    Play,
    GameOver
}


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public InterstitialAdExample interstitialAdExample;

    public GameStatus status = GameStatus.Start;
    public float speed;

    public Bird bird;

    public PipesManager pipesManager;

    public Image startImage;

    public Image gameOverImage;

    public TMP_Text scoreText;

    public TMP_Text recordText;
    int score = 0;

    private float gameOverTimer = 0f;
    private string recordKey = "record";
    private int record;


    public void AddScore()
    {
        score++;
        UpdateScoreText();
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        switch (status)
        {
            case GameStatus.Start:
                StartUpdate();
                break;
            case GameStatus.Play:
                break;
            case GameStatus.GameOver:
                GameOverUpdate();
                break;
        }
    }

    private void StartUpdate()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            StartGame();
        }
    }

    public void Start()
    {
        Application.targetFrameRate = 60;
        startImage.enabled = true;
        gameOverImage.enabled = false;
        scoreText.enabled = false;
        recordText.enabled = true;
        record = PlayerPrefs.GetInt(recordKey);
        UpdateRecordText();
    }

    public void StartGame()
    {
        status = GameStatus.Play;
        bird.StartGame();
        startImage.enabled = false;
        scoreText.enabled = true;
        recordText.enabled = false;
       

    }



    public void GameOver()
    {
        status = GameStatus.GameOver;
        gameOverImage.enabled = true;
        scoreText.enabled = true;
        recordText.enabled = true;
        if(score > record)
        {
            record = score;
            PlayerPrefs.SetInt(recordKey, record);
            UpdateRecordText();
        }
    }

    void GameOverUpdate()
    {
        gameOverTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0)) 

        {
            if(gameOverTimer > 1.5)
            {

            Restart();
            }
        }
    }

    void Restart()

    {
        status = GameStatus.Start;
        bird.Restart();
        pipesManager.Restart();
        startImage.enabled = true;
        gameOverImage.enabled = false;
        score = 0;
        UpdateScoreText();
        gameOverTimer = 0f;
        scoreText.enabled = false;
        recordText.enabled = true;


    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: "+score.ToString();
    }

    private void UpdateRecordText()
    {
        recordText.text = $"Record: " +record.ToString();
    }
}
