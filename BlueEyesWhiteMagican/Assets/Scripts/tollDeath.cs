using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tollDeath : MonoBehaviour
{
    //This script is to set a timer on the trollDeath sprite so it disappears after awhile

    //fields
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        //set the timers starting value
        timer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        //decearse the timer
        timer -= 1.0f * Time.deltaTime;

        if (timer <= 0.9f)
        {
            //destory the troll death sprite
            Destroy(gameObject);
        }
    }
}
