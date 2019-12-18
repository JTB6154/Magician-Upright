using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;//rigidbody for movement
    [SerializeField]
    float speed = 12f;//speed at wich the object moves

    int trollcount = 2;

    //Base Damage of the sword attack
    public int SwordDamage = 50;

    [SerializeField]
    float offset = .03f; //how far in front of the player the sprite exists
    [SerializeField]
    float duration = 5; //the amount of time the fireball is around for.


    FixedMovment Wizard;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        //sets up sword to move in proper direction
        Wizard = GameObject.Find("Wizard").GetComponent<FixedMovment>();
        direction = -Wizard.direction.normalized;

        //legacy testing code
        //gameObject.transform.position = new Vector3(rb.position.x, rb.position.y, 2);
        //print(gameObject.transform.position);

        //moves sword a little in fron of wizard
        rb.transform.position = rb.position + direction * speed * offset;
        //rotates the sword
        rb.MoveRotation(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        //removes the sword if it's around for too long
        Destroy(gameObject, duration);
        //changes name for collision
        gameObject.name = "Sword";
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// handles all collision
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if colliding with the troll
        if (collision.gameObject.name == "Troll")
        {
            //change the troll health
            collision.gameObject.GetComponent<TrollHealth>().health -= (SwordDamage * Wizard.DamageMultipler);
            if (trollcount > 0)
            {
                //decrement the troll counter
                trollcount--;
            }
            else
            {
                //if the sword has gone through three trolls destroy it
                Destroy(gameObject);
            }
        }


        if (collision.gameObject.name != "Potion" && collision.gameObject.name != "Wizard" && collision.gameObject.name != "Fireball" && collision.gameObject.name != "Sword" && collision.gameObject.name != "Troll" && collision.gameObject.name != "Grate")
        {
            //destroy it if it collides with a non-wizard,non-fireball,non-sword,non-troll,non-grate object
            Destroy(gameObject);
        }
    }

}
