using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    //Breanna Henriquez 10/12/19
    //This script is meant to move the fireball

    //fields
    WizardMovement Wizard;
    [SerializeField]
    float speed = 7f; //how fast the fireball moves
    [SerializeField]
    float duration = 5f;
    [SerializeField]
    GameObject sprite;
    Vector3 direction;
    Vector3 velocity;
    Vector3 fireballPosition;
    float angle;
    

    // Start is called before the first frame update
    void Start()
    {
        //get reference to the wizard
        Wizard = GameObject.Find("Wizard").GetComponent<WizardMovement>();

        //set the direction of the bullet
        velocity = -Wizard.direction.normalized * speed;
        fireballPosition = transform.position;
        angle = Wizard.angleOfRotation +90;


        sprite.transform.localRotation = Quaternion.Euler(0, 0, angle);

       
    }

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;

        //call the method to move the bullet
        // Add velocity to vehicle's position
        fireballPosition += velocity*Time.deltaTime;
        transform.position = fireballPosition;

        //destory the fireball if its duration is out
        if(duration < 0)
        {
            Destroy(gameObject);
        }
    }


    
}
