using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardStayIbScreen : MonoBehaviour
{
    //Breanna Henriquez 10/12/19
    //This script is to make sure the wizard stays on screen at all times

    //fields
    WizardMovement wizard;
    Camera main;
    float height;
    float width;

    // Start is called before the first frame update
    void Start()
    {
        //get a reference to the wizard
        wizard = GameObject.Find("Wizard").GetComponent<WizardMovement>();

        //get a refernece to the main camera
        main = Camera.main;

        //set the hight and width of the main camera
        height = 2f * main.orthographicSize;
        width = height * main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        //call the method to make the wizard stay on screen
        OnScreen();
    }

    //method to check the wizard position and change it if it is off screen
    void OnScreen()
    {
        if(wizard.wizardPosition.x < (width/2) * -1)
        {
            //make the position of the wizard the edg of the screen
            wizard.wizardPosition = new Vector3((width / 2) * -1, wizard.wizardPosition.y, 0);
        }
        if (wizard.wizardPosition.y < (height / 2) * -1)
        {
            //make the position of the wizard the edg of the screen
            wizard.wizardPosition = new Vector3(wizard.wizardPosition.x,(height / 2) * -1, 0);
        }
        if (wizard.wizardPosition.x > (width / 2))
        {
            //make the position of the wizard the edg of the screen
            wizard.wizardPosition = new Vector3((width / 2), wizard.wizardPosition.y, 0);
        }
        if (wizard.wizardPosition.y > (height / 2))
        {
            //make the position of the wizard the edg of the screen
            wizard.wizardPosition = new Vector3(wizard.wizardPosition.x, (height / 2), 0);
        }
    }


}
