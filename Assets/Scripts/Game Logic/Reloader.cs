using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reloader : MonoBehaviour
{

    public GameObject gameOverUI;
    public PlayerMovement player;
    public GameObject menuUI;
    
    bool setMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // check to see if player restarted the game
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!menuUI.activeSelf)
            {
                menuUI.SetActive(true);
                Time.timeScale = 0;
            }
            else 
            {
                menuUI.SetActive(false); 
                Time.timeScale = 1;

            }

        }
        // if player health drops below 0 pause the game and say they died
        if (player.health < 0)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
        
    }

    public void continueGame()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1;

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.health = 10;
        Time.timeScale = 1.0f;

    }

    public void quit()
    {
        Application.Quit();

    }

}
