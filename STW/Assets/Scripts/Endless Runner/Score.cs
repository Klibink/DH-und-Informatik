using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//aktualisiert die Punktzahl
public class Score : MonoBehaviour
{
    private float score = 0.0f;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 15;
    private int scoreToNextLevel = 10;

    public TMP_Text scoreText;

    private bool isDead = false;
    public DeathMenu deathMenu;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManagerEndlessRunner>().isRunning)
        {
            if (isDead)
                return;

            if (score >= scoreToNextLevel)
            {
                LevelUp();
            }
            score += Time.deltaTime * difficultyLevel;
            scoreText.text = ((int)score).ToString();
        }
            
    }

    public float GetScore()
    {
        return score;
    }

    private void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;

        scoreToNextLevel *= 2;
        difficultyLevel++;

        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);
    }

    public void OnDeath()
    {
        isDead = true;
        deathMenu.ToggleEndMenu(score);
    }
}
