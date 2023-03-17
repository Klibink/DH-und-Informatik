using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Aktualisiert die aktuelle Anzahl der gesammelten Münzen
public class CoinManager : MonoBehaviour
{
    public TMP_Text coinText;
    public GameObject gameManager;
    public GameObject winCanvas;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoinCounter();
    }

    public void UpdateCoinCounter()
    {
        coinText.text = gameManager.GetComponent<GameManagerEndlessRunner>().currentCoins.ToString() + "/" + gameManager.GetComponent<GameManagerEndlessRunner>().maxCoins + " Münzen";
    }
}
