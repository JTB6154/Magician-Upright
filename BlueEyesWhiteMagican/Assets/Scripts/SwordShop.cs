using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordShop : MonoBehaviour
{
    [SerializeField]
    int cost = 1000;
    bool touchplayer = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && touchplayer)
        {
            if (GameObject.Find("PointManager").GetComponent<PointManagementScript>().removePoints(cost))
            {
                GameObject.Find("Wizard").GetComponent<FixedMovment>().equipSword();
                Destroy(gameObject);
            }
        }
    }

    private void OnGUI()
    {
        GUI.backgroundColor = Color.gray;
        GUI.contentColor = Color.yellow;
        if (touchplayer)
        {
            GUI.Box(new Rect((Screen.width / 2f) - 150f, Screen.height * .8f - 25f, 150f, 50f), output());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wizard")
        {
            touchplayer = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wizard")
        {
            touchplayer = false;
        }
    }
    private string output()
    {
        return "Press F to buy \n Cost: " + cost.ToString() + " pts";
    }
}
