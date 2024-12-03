using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject loseMenu;
    public GameObject startMenu;
    public GameObject player;
    [SerializeField] public Score score = new Score();
    public Text scoreText;
    public Text voucerText;

    int scoreValue = 0;
    int level;

    // Start is called before the first frame update
    void Start()
    {
        startMenu.SetActive(true);
        score.setScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreValue != score.scoreValue)
        {
            scoreValue = score.scoreValue;
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        int scoreDifficulty = 10 * level;

        scoreText.text = "Score: " + scoreValue;
        voucerText.text = "Voucher: " + scoreValue / scoreDifficulty;

        if (scoreValue % scoreDifficulty == 0)
        {
            level++;
        }
    }

    public void setStart()
    {
        Time.timeScale = 1;
        startMenu.SetActive(false);
    }

    public void setLose()
    {
        Time.timeScale = 0;
        loseMenu.SetActive(true);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
