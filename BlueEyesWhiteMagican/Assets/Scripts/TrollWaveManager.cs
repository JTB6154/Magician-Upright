using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollWaveManager : MonoBehaviour
{
    //John Bateman 10/13/19
    //handles trolls spawining
    // Start is called before the first frame update

    public List<GameObject> spawnpoints = new List<GameObject>(); //grates are passed in as player comes in range of them through gratespawnadded.cs
    [SerializeField]
    GameObject enemy;//the enemy that is spawned
    [SerializeField]
    int initialwavesize = 3; //size of the first wave
    [SerializeField]
    int waveIncrement = 3; //amount of enemies added per wave
    [SerializeField]
    float waveDelay = 5f; //time between waves
    float waveDelayTimer;
    [SerializeField]
    float spawnDelay = .5f; //time between spawning enemies
    float spawnDelayTimer;

    int waveNumber = 0;

    [SerializeField]
    int numTrollsinWave;
    [SerializeField]
    int livingTrolls;

    public float waveCount
    {
        get
        {
            return waveNumber;
        }
    }


    void Start()
    {
        startNewWave();
        spawnDelayTimer = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //if there are no living trolls
        if (livingTrolls <= 0) //using less than in case of errors.
        {
            //decrement the wave delay timer
            waveDelayTimer -= Time.deltaTime;

            //if the wave delay timer is up
            if (waveDelayTimer < 0)
            {
                //increment the wave number and begin a new wave
                waveNumber += 1;
                startNewWave();
            }
        }
        else
        {
            //decrement the spawn delay timer
            spawnDelayTimer -= Time.deltaTime;

            //if the spawn timer is below zero, and there is a spawn point in range, and there are more trolls to spawn
            if (spawnDelayTimer < 0 && spawnpoints.Count >0 &&numTrollsinWave >0)
            {
                //get a random spawn location from one that is in range
                int SpawnLocation = Random.Range(0, spawnpoints.Count);
                //intantiate a troll at a spawn point
                GameObject.Instantiate(enemy, spawnpoints[SpawnLocation].transform.position, Quaternion.identity);

                //decrease the amount of remaining trolls in the wave
                numTrollsinWave -= 1;
                //reset the delay between enemy spawns
                spawnDelayTimer = spawnDelay;
            }
        }
        

    }

    /// <summary>
    /// called by the troll when it dies to decrease the number of trolls alive
    /// </summary>
    public void TrollDeath()
    {
        livingTrolls -= 1;
    }

    /// <summary>
    /// starts a new wave
    /// </summary>
    private void startNewWave()
    {
        //reset delay timer
        waveDelayTimer = waveDelay;
        //reset number of living trolls in current wave and number of trolls in wave
        numTrollsinWave = livingTrolls = initialwavesize +waveNumber*waveIncrement;

    }

    public void TrollDespawn()
    {
        numTrollsinWave += 1;
    }
}
