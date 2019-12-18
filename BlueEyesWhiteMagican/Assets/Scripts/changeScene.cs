using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    //10/13/19
    //Script is to change between the different scenes of our game
    bool start;
    bool sample;
    bool gameover;
    public GameObject wizard;
    float timer;
    bool startTimer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 2f;
        startTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        //call the method to update the scene
        checkScene();
    }

    //method to check the scenes
    void checkScene()
    {
        if(SceneManager.GetActiveScene().name == "Start Menu")
        {
            //change scene based on user input
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("LevelLayout");
            }
            if(Input.GetKeyDown(KeyCode.C))
            {
                SceneManager.LoadScene("Credits");
            }
        }
        else if(SceneManager.GetActiveScene().name == "LevelLayout")
        {        
            if (wizard.activeInHierarchy == false)
            {
                //set the timer to true
                startTimer = true;

                if(startTimer)
                {
                    timer -= 1.0f * Time.deltaTime;

                    if(timer <= 0.0f)
                    {
                        SceneManager.LoadScene("Game Over");
                        startTimer = false;
                    }
                }           
            }
        }
        else if(SceneManager.GetActiveScene().name == "Game Over")
        {
            //change the scene based on user imput
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Start Menu");
            }
        }
        else if(SceneManager.GetActiveScene().name == "Credits")
        {
            if(Input.GetKeyDown(KeyCode.B))
            {
                SceneManager.LoadScene("Start Menu");
            }
        }

    }
}
