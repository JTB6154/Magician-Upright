using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionCollision : MonoBehaviour
{
    //Breanna Henriquez 10/13/19
    //This script is to give a mysteroius booast back to the player

    // Start is called before the first frame update
    void Start()
    {
        //change name for collision
        gameObject.name = "Potion";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collided with the wizard
        if (collision.gameObject.name == "Wizard")
        {
            //give the wizard his power up
            collision.gameObject.GetComponent<FixedMovment>().potionBuff();

            //destroy this game object
            Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.name == "Wizard")
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
