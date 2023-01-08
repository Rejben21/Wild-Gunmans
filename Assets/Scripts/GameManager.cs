using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject bomb;
    private float SpawnTimer;

    private bool hasFinished = false;

    public PlayerController[] players;
    public Text countText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnTimer = 5;

        StartCoroutine(StartLevelCo());
    }

    void Update()
    {
        SpawnBomb();

        RestartLevel();
    }

    public void PlayerOneWin()
    {
        Debug.Log("Player 1 Wins!");
        countText.text = "Player 1 Wins! Press 'R' To restart";
        hasFinished = true;
        Time.timeScale = 0;
    }

    public void PlayerTwoWin()
    {
        Debug.Log("Player 2 Wins!");
        countText.text = "Player 2 Wins! Press 'R' To restart";
        hasFinished = true;
        Time.timeScale = 0;
    }

    void RestartLevel()
    {
        if(Input.GetKeyDown(KeyCode.R) && hasFinished)
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }
    }

    void SpawnBomb()
    {
        if(SpawnTimer <= 0)
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            SpawnTimer = 10;
        }
        else
        {
            SpawnTimer -= Time.deltaTime;
        }
    }

    public IEnumerator StartLevelCo()
    {
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(1);

        countText.text = "3";

        yield return new WaitForSecondsRealtime(1);

        countText.text = "2";

        yield return new WaitForSecondsRealtime(1);

        countText.text = "1";

        yield return new WaitForSecondsRealtime(1);

        countText.text = "Fire!";
        players[0].canMove = true;
        players[1].canMove = true;
        Time.timeScale = 1;

        yield return new WaitForSecondsRealtime(1);

        countText.text = "";
    }
}
