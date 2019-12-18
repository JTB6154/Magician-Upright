using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballManager : MonoBehaviour
{
    //Breanna Henriquez 10/12/19
    //This script is to create and move the fireball when the user presses space

    //fields
    public GameObject fireBall;
    WizardMovement wizard;
    public Vector3 fireballOffset = new Vector3(0,0);

    // Start is called before the first frame update
    void Start()
    {
        //get a refernece to the wizard 
        wizard = GameObject.Find("Wizard").GetComponent<WizardMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //check to see that the user has pressed space
        if(Input.GetMouseButtonDown(0))
        {
            //create a new bullet
            Instantiate(fireBall, wizard.wizardPosition, Quaternion.identity);
        }
    }
}
