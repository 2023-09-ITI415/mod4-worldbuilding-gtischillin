using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    static private UI S;
    public Text uitCoins;
    public int CoinsCollected;
    public GameObject WinGameCanvas;
    public GameObject ResultsCanvas;

    void Start()
    {
        S = this;
        CoinsCollected = 0;
        UpdateGUI();
        WinGameCanvas.SetActive(false);
        ResultsCanvas.gameObject.SetActive(false);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) 
        {
            UI.COIN_COLLECTED();
            Destroy(other.gameObject);
        }
    }

    static public void COIN_COLLECTED()
    {
        S.CoinsCollected++;
        S.UpdateGUI();
    }

    public void UpdateGUI()
    {
        uitCoins.text = "Coins Collected: " + CoinsCollected + "/15";
        if (CoinsCollected >= 15)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        WinGameCanvas.SetActive(true);
        DisplayResults();
    }
    private void DisplayResults()
    {
        ResultsCanvas.gameObject.SetActive(true);
    }
}