using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public float restartTime = 1f;

    void ShowGameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0.1f;
        Invoke("Restart", restartTime);
    }

    void Restart()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(0);
    }
}
