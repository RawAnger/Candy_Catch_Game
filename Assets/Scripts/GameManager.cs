using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject lifesHolder;
    public GameObject gameOverMenu;

    int score = 0;
    int lifes = 3;

    bool gameOver = false;

    public Text scoreText;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreKeeper()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    public void LifeCounter()
    {
        if(lifes > 0)
        {
            lifes--;
            print(lifes);

            lifesHolder.transform.GetChild(lifes).gameObject.SetActive(false);
        }
        if(lifes <= 0)
        {
            gameOver = true;

            GameOver();
        }
    }

    public void GameOver()
    {
        CandySpawner.instance.StopSpawnCandies();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        gameOverMenu.SetActive(true);
        print("GameOver");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }


    public void Return()
    {
        SceneManager.LoadScene("Menu");
    }
}

