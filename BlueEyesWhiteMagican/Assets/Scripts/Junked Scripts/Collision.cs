using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    //Breanna Henriquez 10/12/19
    //This script is to detect the collide and lower health;


    //MOVED TO FIXED MOVEMENT

    //public float maxHealth = 100f;
    //public float health;
    //public GameObject wizard;
    //public GameObject wizardDead;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    health = maxHealth;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //if the wizards health is zero destory the object// later create a dead wizard sprite in its place
    //    if(health <= 0)
    //    {
    //        //create the new wizard dead sprite when the players health is 0
    //        Instantiate(wizardDead, wizard.transform.position, Quaternion.identity);

    //        wizard.SetActive(false);
    //    }
    //}
    //public void damage()
    //{
    //    health -= 10;
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.name == "Trolgre Idle Sprite Fix")
    //    {
    //        health -= 10f;

    //    }  
    //}

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Troll")
        {
            health -= 10f;
        }
    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Troll")
        {
            health -= 10f;
        }
    }*/
}
