using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    //Breanna Henriquez 10/12/19
    //This scripts is to detect collision with the troll

    //fields 
    TrollHealth troll;

    // Start is called before the first frame update
    void Start()
    {
        troll = GameObject.Find("Troll").GetComponent<TrollHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
