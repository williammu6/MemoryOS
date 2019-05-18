using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameScript : MonoBehaviour
{
    [SerializeField] private GameObject PlayAgainBtn;
    public TextMeshProUGUI ScoreText;
    public int score;

    public int rows = 2;
    public int cols = 8;

    void Start()
    {
        score = 0;
    }

    public void AddScore()
    {
        score++;
        ScoreText.text = "Score: " + score;
    }

    public void CheckGame()
    {
        if (score == (int)(rows * cols / 2))
        {
            PlayerWon();
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayerWon()
    {
        PlayAgainBtn.SetActive(true);
    }
}
