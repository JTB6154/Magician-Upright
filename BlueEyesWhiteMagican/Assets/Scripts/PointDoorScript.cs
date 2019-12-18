using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDoorScript : MonoBehaviour
{
    [SerializeField]
    int cost = 500; //cost to opent the door
    bool touchplayer = false; //keeps track of if the player is touching the door


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If player is touching the door and pressing f
        if(Input.GetKeyDown(KeyCode.F) && touchplayer)
        {
            //check if the player has enough points to open the door
            if(GameObject.Find("PointManager").GetComponent<PointManagementScript>().removePoints(cost))
            {
                //remove the door if they do
                Destroy(gameObject);
            }
        }
    }

    private void OnGUI()
    {
        GUI.backgroundColor = Color.gray; //set up gui box
        GUI.contentColor = Color.yellow;

        if (touchplayer) //display the gui if the plaer is touching the door
        {
            GUI.Box(new Rect((Screen.width / 2f)-150f, Screen.height *.8f -25f, 150f, 50f), output());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when player collides with box set that it is touching the player
        if(collision.gameObject.name == "Wizard")
        {
            touchplayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //when player stops touching the box sset that it is not touching the player
        if (collision.gameObject.name == "Wizard")
        {
            touchplayer = false;
        }
    }

    //get the string that is used to output to gui
    private string output()
    {
        return "Press F to open \n Cost: " + cost.ToString() + " pts";
    }
}
