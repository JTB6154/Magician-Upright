using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrateSpawnAdder : MonoBehaviour
{
    //john bateman
    //handles spawning trolls in range of the player, spawners outside range of the player are removed, spawners in range are added.

    bool addedToSpawn = false;
    Vector2 position;
    [SerializeField]
    float spawnerdistance = 8; //distance at wich spawner activates

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector2(transform.position.x,transform.position.y);
        gameObject.name = "Grate";

    }

    // Update is called once per frame
    void Update()
    {
        //get distance between this object and the grate
        if (GameObject.Find("Wizard") != null)
        {
            Vector2 magnitude = GameObject.Find("Wizard").GetComponent<Rigidbody2D>().position - position;

            //if the grate is 8 units from the wizard and not already list of spawns 
            if (magnitude.magnitude <= spawnerdistance && !addedToSpawn)
            {
                //add the 
                GameObject.Find("TrollSpawner").GetComponent<TrollWaveManager>().spawnpoints.Add(gameObject);
                addedToSpawn = true;
            }
            else if (magnitude.magnitude > spawnerdistance && addedToSpawn)
            {
                //if the wizard is out of range and the grate is in list, remove it from list
                GameObject.Find("TrollSpawner").GetComponent<TrollWaveManager>().spawnpoints.Remove(gameObject);
                addedToSpawn = false;
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Player" && !addedToSpawn)
    //    {
    //        GameObject.Find("TrollSpawner").GetComponent<TrollWaveManager>().spawnpoints.Add(gameObject);
    //        addedToSpawn = true;
    //    }
    //}
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player" && !addedToSpawn)
    //    {
    //        GameObject.Find("TrollSpawner").GetComponent<TrollWaveManager>().spawnpoints.Add(gameObject);
    //        addedToSpawn = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Player" && addedToSpawn)
    //    {
    //        GameObject.Find("TrollSpawner").GetComponent<TrollWaveManager>().spawnpoints.Remove(gameObject);
    //        addedToSpawn = false;
    //    }
    //}
}
