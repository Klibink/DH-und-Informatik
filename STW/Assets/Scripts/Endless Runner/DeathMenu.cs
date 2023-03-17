using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//Steuert das Men�, das auftaucht, wenn der Spieler gestorben ist
public class DeathMenu : MonoBehaviour
{
    public TMP_Text scoreText;
    public Image backgroundImg;

    private bool isShown = false;
    private float transition = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShown)
        {
            return;
        }
        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black,transition);
    }

    //Aktiviert das Endmen�-Canvas
    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        isShown = true;
    }

    //Startet das Spiel neu, wenn der Spieler auf "Play" dr�ckt
    public void RestartGame()
    {
        GameObject.Find("GameManager").GetComponent<GameManagerEndlessRunner>().timeSinceStart = 0;
        GameObject.Find("GameManager").GetComponent<GameManagerEndlessRunner>().CheckCoinStatus();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    //�ndert die aktuelle Szene zur gew�nschten Szene
    public void ChangeCurrentScene(int sceneIndex)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Test geschafft");
        if (GameObject.Find("GameManager").GetComponent<GameManagerEndlessRunner>().winCanvasShown)
        {
            Debug.Log("WinCanvas wurde erreicht");
            sceneIndex = currentSceneIndex + 1;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}
