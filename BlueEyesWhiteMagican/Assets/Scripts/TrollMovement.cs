using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollMovement : MonoBehaviour
{
    //Breanna Henriquez 10/12/19
    //This script is too make the troll move randomly through out the room

    //fields
    Vector2 direction;
    Vector2 velocity;
    [SerializeField]
    float speed = 4.5f;
    [SerializeField]
    float speed2 = 4.3f;
    [SerializeField]
    public Rigidbody2D rb;
    GameObject wizard;
    [SerializeField]
    GameObject sprite;
    float angle;
    FixedMovment wizardHealth;
    bool randDirection = false;
    [SerializeField]
    Sprite[] attackSprites = new Sprite[2];
    [SerializeField]
    Sprite idle;
    [SerializeField]
    GameObject hurtbox;

    [SerializeField]
    float trollLeashLength = 10f;
    
    
    


    bool trollattack = false;
    [SerializeField]
    float trollattackduration = 0.45f;
    [SerializeField]
    float activeHitTimePercent = 0.5f;

    float trollattacktimer;
    bool hurtBoxThrown = false;
 
   
    // Start is called before the first frame update
    void Start()
    {
        //set the velocity vector to zero
        velocity = new Vector2(0, 1);
        direction = new Vector2(1, 0);

        trollattacktimer = trollattackduration;

        wizard = GameObject.Find("Wizard");
        wizardHealth = wizard.GetComponent<FixedMovment>();
        speed2 = 0.05f;

    }

    // Update is called once per frame
    void Update()
    {
        //wizard = GameObject.Find("Wizard");
        //wizardHealth = wizard.GetComponent<FixedMovment>(); //gets the wizards health

        /*if (wizardHealth.health > 0)
        {
            direction = wizard.GetComponent<Rigidbody2D>().position - rb.position;
            velocity = direction;

            angle = Mathf.Atan2(velocity.normalized.y, velocity.normalized.x) * Mathf.Rad2Deg - 90;
            sprite.transform.rotation = Quaternion.Euler(0, 0, angle);

            velocity = velocity.normalized * speed * Time.deltaTime;
            rb.MovePosition(rb.position + velocity);
        }*/

        //this statement handles the troll movement
        if (GameObject.Find("Wizard") != null) //if the wizards health is still alive
        {
            //follow the wizard
            trollFollow();
         
        }
        else
        {
            //otherwise get a random direction and begin to move the wizard
            if(!randDirection)
            {
                RandomMovement();
                randDirection = true;
            }

            TrollMove();
        }


        //handles troll attacking
        if(trollattack)
        {
            //if the troll is attacking
            trollattacktimer -= Time.deltaTime; //decrement attack timer

            if (trollattacktimer > activeHitTimePercent * trollattackduration)
            {
                //change the sprite to the wind up
                GetComponentInChildren<SpriteRenderer>().sprite = attackSprites[0];
                //print("Attacking"); //code for testing
            }
            else if(trollattacktimer > 0)
            {
                //make the sprite the attack sprite
                GetComponentInChildren<SpriteRenderer>().sprite = attackSprites[1];
                if (!hurtBoxThrown)
                {
                    //print("Hurt box thrown");//testing code
                    //create the hurtbox
                    GameObject.Instantiate(hurtbox, gameObject.transform.position, Quaternion.Euler(0f, 0f, angle));
                    hurtBoxThrown = true;
                }
            }
            else
            {
                //on the last frame
                //reset troll for next attack
                trollattacktimer = trollattackduration;
                hurtBoxThrown = false;
                GetComponentInChildren<SpriteRenderer>().sprite = idle;
                trollattack = false;
            }

        }
     
    }

    void TrollMove()
    {
        //moves the troll
        speed = 0.05f; 

        velocity = direction * speed;

        rb.MovePosition(rb.position + velocity);
    }

    void trollFollow()
    {
        //get the wizard
        wizard = GameObject.Find("Wizard");

        //get the wizards position
        direction = wizard.GetComponent<Rigidbody2D>().position - rb.position;
        if(direction.magnitude > trollLeashLength)
        {
            GameObject.Find("TrollSpawner").GetComponent<TrollWaveManager>().TrollDespawn();
            Destroy(gameObject);
        }

        velocity = direction;

        //gets the angle
        angle = Mathf.Atan2(velocity.normalized.y, velocity.normalized.x) * Mathf.Rad2Deg - 90;
        //rotate troll sprite to face the 
        sprite.transform.rotation = Quaternion.Euler(0, 0, angle);

        if (trollattack)
        {
            //slower movement for when troll is attacking
            velocity = velocity.normalized * speed2 * Time.deltaTime;
        }
        else
        {
            //regular troll movment
            velocity = velocity.normalized * speed * Time.deltaTime;
        }

        rb.MovePosition(rb.position + velocity);

        
     
    }

    //method to determine which direction the troll will move in
    void RandomMovement()
    {
        //generate a random number
        float rand = Random.Range(0.0f, 0.4f);

        //move in a random direction
        if(rand < 0.1f)
        {
            direction = new Vector2(-1, 0);
        }
        else if(rand < 0.2f)
        {
            direction = new Vector2(0, 1);
        }
        else if(rand < 0.3f)
        {
            direction = new Vector2(1, 0);
        }
        else if(rand < 0.4f)
        {
            direction = new Vector2(0, -1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision.gameObject.name == "WallTiles")
        {
            //legacy code
            //csll the method to change the direction
            //RandomMovement();

        }*/

        if(collision.gameObject.name == "Wizard")
        {
            trollattacktimer = trollattackduration;
            trollattack = true;
        }
    }


    //change the direction of the troll when it collides with a wall
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "WallTiles" || collision.gameObject.name == "Troll")
        {
            //call the method to change the direction
            RandomMovement();
        }
    }

    
}
