using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovment : MonoBehaviour
{
    [SerializeField]
    float movespeed = 5f;
    [SerializeField]
    float maxspeed = 10f;
    public Rigidbody2D rb;

    Vector2 movement;

    [SerializeField]
    GameObject sprite;

    public float DamageMultipler = 1f;

    public Vector2 direction = new Vector2();
    float angle;

    [SerializeField]
    Camera mainCam;

    [SerializeField]
    GameObject fireBall;
    [SerializeField]
    GameObject sword;

    bool swordson = false;

    //moved in from collision to handle health
    public float maxHealth = 100f;
    public float health;
    public GameObject wizardDead;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;//set the health to max
    }

    // Update is called once per frame
    /// <summary>
    /// Handles movement
    /// </summary>
    void Update()
    {
        //gets input from wasd or from arrow keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //gets the direction the wizard is facing using the mouse
        direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg +90; //fix angle
        //rotate the sprite
        sprite.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        //move the main camera
        mainCam.transform.position = rb.position;

        //if the left click is depressed
        if (Input.GetMouseButtonDown(0) )
        {
            if (swordson) //if swords have been aquired
            {
                //spawn a sword
                Instantiate(sword, rb.transform.position, Quaternion.Euler(0, 0, angle + 90));
            }
            else
            {
                //if the swords have not been aquired, spawn the default fireball instead
                Instantiate(fireBall, rb.transform.position, Quaternion.Euler(0, 0, angle + 90));
            }
        }


        //if the wizards health is zero destory the object// later create a dead wizard sprite in its place
        if (health <= 0)
        {
            //create the new wizard dead sprite when the players health is 0
            Instantiate(wizardDead, gameObject.transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }

    }

    /// <summary>
    /// moves the player
    /// </summary>
    private void FixedUpdate()
    {
        //update the players position
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// equips the player with a powerup
    /// called externally by swordshop to give player swords instead of fireball.
    /// </summary>
    public void equipSword()
    {
        swordson = !swordson;
    }

    /// <summary>
    /// called externally by hurtboxes when they collide with the wizard
    /// </summary>
    public void damage()
    {
        
        health -= 25;
    }

    public void OnGUI()
    {
        
        //draws the health and move speed to the screen
        GUI.backgroundColor = Color.gray;
        GUI.contentColor = Color.yellow;
        GUI.Box(new Rect(10f, 10f, 150f, 50f), output());
    }

    public void potionBuff()
    {
        //r for holding random
        int r;

        //if movement is already to high don't generate a movement powerup
        if (movespeed < maxspeed)
        {
            r = Random.Range(0, 4);
        }
        else
        {
            r = Random.Range(0, 3);
        }

        //print(r);//enable for testing

        //select powerup to give
        switch (r)
        {
            //give health refil
            case 0:
                health += Mathf.Round(.5f * maxHealth);

                if(health > maxHealth)
                {
                    health = maxHealth;
                }

                break;
            //increase max health
            case 1:
                maxHealth += Mathf.Round(.25f * maxHealth);
                break;
            //increase Damage multiplier
            case 2:
                DamageMultipler += Mathf.Round(DamageMultipler * .2f);
                break;
            //increase move speed
            case 3:
                movespeed += Mathf.Round(.1f * movespeed);
                break;
        }



    }

    //output for gui
    private string output()
    {
        //displays health and current move speed
        return "Health: " + health.ToString() + " / " + maxHealth.ToString() + "\nMove speed: " + movespeed.ToString() + "\n Damage Multipler: " + DamageMultipler.ToString(); 
    }
}
