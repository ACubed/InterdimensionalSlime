using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riser : MonoBehaviour
{
    bool pressed = false;
    public GameObject min;
    public GameObject max;
    public bool upDir = true; //if true will move up. False will move down
    Vector3 fastSpeed = new Vector3(0f, 0.1f, 0f);
    Vector3 slowSpeed = new Vector3(0f, 0.01f, 0f);
    public GameObject obj;

    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (upDir)
        {
            if (pressed && obj.transform.position.y <= max.transform.position.y)
            {
                obj.transform.position += fastSpeed;
            }
            else if (!pressed && obj.transform.position.y > min.transform.position.y)
            {
                obj.transform.position -= slowSpeed;
            }
        } else
        {
            if (pressed && obj.transform.position.y > max.transform.position.y)
            {
                obj.transform.position -= fastSpeed;
            }
            else if (!pressed && obj.transform.position.y <= min.transform.position.y)
            {
                obj.transform.position += slowSpeed;
            }
        }
    }



    public void Activate() //activate the riser
    {
        pressed = true;
    }

    public void Deactivate() //deactivate the riser
    {
        pressed = false;
    }

}
