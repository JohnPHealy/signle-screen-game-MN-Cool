using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject WinText;
    [SerializeField] private UnityEvent<string> addScore;
    private Vector3 startPos;
    private Vector3 enemyStart, enemy2Start, enemy3Start;
    private int score;

    private void Start()
    {
        startPos = player.transform.position;
        enemyStart = enemy.transform.position;
        enemy2Start = enemy2.transform.position;
        enemy3Start = enemy3.transform.position;
        score = 0;
        UpdateUI();
        PauseGame();
    }

    public void RespawnPlayer()
    {
        player.transform.position = startPos;
        score = 0;
        UpdateUI();
    }

    public void RespawnEnemy()
    {
        enemy.transform.position = enemyStart;
        UpdateUI();
    }

    public void RespawnEnemy2()
    {
        enemy2.transform.position = enemy2Start;
        UpdateUI();
    }

    public void RespawnEnemy3()
    {
        enemy3.transform.position = enemy3Start;
        UpdateUI();
    }

    public void AddScore(int scoreAmt)
    {
        score += scoreAmt;
        UpdateUI();
    }

    private void UpdateUI()
    {
        addScore.Invoke(score.ToString());
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }

    public void Win()
    {
        if (score >= 300)
        {
            WinText.SetActive(true);
            Time.timeScale = 0.25f;
        }
    }
}