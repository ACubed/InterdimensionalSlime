using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDown : MonoBehaviour
{
    //public bool pressed = false;
    public LockToFriend ltk;
    public bool bigOne = false;
    public bool littleOne = false;
    public GameObject min;
    Vector3 change = new Vector3(0f, 0.25f, 0f);
    public GameObject elevatorObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((bigOne && littleOne) || ((bigOne || littleOne) && ltk.locked) && elevatorObject.transform.position.y >= min.transform.position.y)
        {
            elevatorObject.transform.position -= change/2;
        } //end of this shit

    }


    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.tag == "Player" && string.Compare(collision.collider.name, "Big Hero") == 0)
        {
            //Debug.Log("Collided: Big Hero");
            bigOne = true;
        }
        else if (collision.collider.tag == "Player" && string.Compare(collision.collider.name, "Little Hero") == 0)
        {
            //Debug.Log("Collided: Little Hero");
            littleOne = true;
        }
    } //end of method onced2d

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && string.Compare(collision.collider.name, "Big Hero") == 0)
        {
            //Debug.Log("Left: Big Hero");
            bigOne = false;
        }
        else if (collision.collider.tag == "Player" && string.Compare(collision.collider.name, "Little Hero") == 0)
        {
            //Debug.Log("Left: Little Hero");
            littleOne = false;
        }
    }
}