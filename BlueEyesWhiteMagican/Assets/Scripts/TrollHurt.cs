using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollHurt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //hurtbox only lasts for .2 seconds
        Destroy(gameObject, .2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// called when this collider hits something
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Hit Wizard"); //code for testing
        //if the hit thing is the wizard
        if (collision.gameObject.name == "Wizard")
        {
            //get it's fixedmovement componenet and damage it
            collision.gameObject.GetComponent<FixedMovment>().damage();
        }
    }
}
