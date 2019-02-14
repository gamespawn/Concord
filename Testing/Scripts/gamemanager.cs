using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject StartScreen;
    public PlayerMotion player;

    // Start is called before the first frame update
    void Start()
    {
        StartScreen.SetActive(true);
    }

    public void blah()
    {
        StartScreen.SetActive(false);
        player.BeginGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
