using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    bool pressed = false;
    Vector3 min = new Vector3(1.186707f, 0.198592f, 1f);
    Vector3 max = new Vector3(1.186707f, 5f, 1f);
    Vector3 change = new Vector3(0f, 0.01f, 0f);
    public GameObject elevatorObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!pressed && elevatorObject.transform.localScale.y >= min.y)
        {
            elevatorObject.transform.localScale -= change;
            elevatorObject.transform.position -= change/2;
        }
        else if (pressed && elevatorObject.transform.localScale.y <= max.y)
        {
            elevatorObject.transform.localScale += change;
            elevatorObject.transform.position += change/2;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pressed = true;

        } //end of collision detection 
    }

    public void Activate()
    {
        pressed = true;
    }

    public void Deactivate()
    {
        pressed = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pressed = false;

        } //end of collision detection 
    }

}
