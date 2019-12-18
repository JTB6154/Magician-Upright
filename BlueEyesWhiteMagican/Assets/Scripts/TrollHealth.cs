using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollHealth : MonoBehaviour
{
    //Breanna Henriquez 10/12/19
    //This script is to set the health of the trolls

    //fields
    public float health =100f;
    public float HealthMod = .1f;
    public GameObject potion;
    public GameObject trollDead;

    [SerializeField]
    int pointValue = 100;

    // Start is called before the first frame update
    void Start()
    {
        //change name for collision detection
        gameObject.name = "Troll";
        health += health * HealthMod * GameObject.Find("TrollSpawner").GetComponent<TrollWaveManager>().waveCount;

    }

    // Update is called once per frame
    void Update()
    {
        //when the troll is dead
        if(health <= 0)
        {
            //check if it has a random drop
            randomDrop();

            Instantiate(trollDead, gameObject.transform.position, Quaternion.identity);

            //tell the points manager that it has died and to add the points
            GameObject.Find("PointManager").GetComponent<PointManagementScript>().addPoints(pointValue);

            //tell the spawner that it has died
            GameObject.Find("TrollSpawner").GetComponent<TrollWaveManager>().TrollDeath();

            //destroy the game object
            Destroy(gameObject);
        }
    }

    //method to determine if the troll should drop a potion
    void randomDrop()
    {
        //generate a random number 
        float rand = Random.Range(0.0f, 100.0f); //generate a value between 1 and 100
        //float rand = 1; //used for testing

        //check the condition
        if(rand < 25)
        {
            Instantiate(potion, GetComponent<Rigidbody2D>().position, Quaternion.identity);
        }
    }
}
