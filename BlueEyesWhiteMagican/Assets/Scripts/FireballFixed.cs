using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballFixed : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;//rigidbody for movement
    [SerializeField]
    float speed = 5f;//speed at wich the object moves

    //Base Damage of the fireball attack
    public int FireBallDamage = 25;

    [SerializeField]
    float offset = .03f; //how far in front of the player the sprite exists
    [SerializeField]
    float duration = 5; //the amount of time the fireball is around for.

    FixedMovment Wizard;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        //get the direction the fireball is going in from the wizard
        if (GameObject.Find("Wizard") != null)
        {
            Wizard = GameObject.Find("Wizard").GetComponent<FixedMovment>();
        }
        direction = -Wizard.direction.normalized;

        //set the position just in front of the wizard
        rb.transform.position = rb.position + direction * speed * offset;
        rb.MoveRotation(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        //destroy the object after duration is up
        Destroy(gameObject, duration);
        //set name for collision testing
        gameObject.name = "Fireball";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// update the position of the fireball
    /// </summary>
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

   
    /// <summary>
    /// handles fireball colliding with other objects.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Troll")
        {
            collision.gameObject.GetComponent<TrollHealth>().health -= (FireBallDamage * Wizard.DamageMultipler);
        }

        if(collision.gameObject.name != "Wizard" && collision.gameObject.name != "Fireball" && collision.gameObject.name != "Sword" && collision.gameObject.name != "Grate" &&collision.gameObject.name != "Potion")
        {
            Destroy(gameObject);
        }
    }

    //removed due to changes in troll structure
    //{

    //    if (collision.name == "Trolgre Idle Sprite Fix")
    //    {
    //        collision.GetComponent<TrollHealth>().health -= 25;
    //    }

    //    Destroy(gameObject);

    //}

    //removed due to changes in fireball
    /*private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Troll")
        {
            collision.gameObject.GetComponent<TrollHealth>().health -= 25;

        }
        Destroy(gameObject);
    }*/
}
