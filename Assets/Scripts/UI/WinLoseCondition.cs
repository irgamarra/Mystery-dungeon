using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseCondition : MonoBehaviour
{
    GameObject loseScreen;
    GameObject winScreen;

    public GameObject player;
    public GameObject enemy;

    private void Start()
    {
        loseScreen = GameObject.Find("Canvas/Lose Screen");
        winScreen = GameObject.Find("Canvas/Win Screen");

        loseScreen.SetActive(false);
        winScreen.SetActive(false);

        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy/Body");

    }

    public void Update()
    {
        //Lose conditions:
        if (player.GetComponent<PlayerHP>().currentHealth == 0)
        {
            Lose();
        }

        //Win conditions:
        if(enemy.GetComponent<Properties>().currentHP == 0)
        {
            Win();
        }
    }
    public void Win()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Lose()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
