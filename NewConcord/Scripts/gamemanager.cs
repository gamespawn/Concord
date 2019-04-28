using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject RetryScreen;
    public PlayerMotion player;

    private float playerHealth = 1.0f;
    public bool gameStart = false;

    // Start is called before the first frame update
    void Start()
    {
        StartScreen.SetActive(true);
        RetryScreen.SetActive(false);
    }

    public void startGame()
    {
        StartScreen.SetActive(false);
        gameStart = true;
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Town");
    }

    public void endGame()
    {
        #if UNITY_EDITOR
          UnityEditor.EditorApplication.isPlaying = false;
        #else
          Application.Quit();
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<PlayerStats>().currHealth;
        if(playerHealth <= 0.0f)
        {
            RetryScreen.SetActive(true);
        }
    }
}
