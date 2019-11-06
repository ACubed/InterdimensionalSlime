using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    bool pressed = false;
    public GameObject min;
    public GameObject max;
    public bool rightDir = true; //if true will move right. False will move left
    Vector3 fastSpeed = new Vector3(0.1f, 0f, 0f);
    Vector3 slowSpeed = new Vector3(0.02f, 0f, 0f);
    public GameObject obj;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rightDir)
        {
            if (pressed && obj.transform.position.x < max.transform.position.x)
            {
                obj.transform.position += fastSpeed;
            }
            else if (!pressed && obj.transform.position.x >= min.transform.position.x)
            {
                obj.transform.position -= slowSpeed;
            }
        }
        else
        {
            if (pressed && obj.transform.position.x > min.transform.position.x)
            {
                obj.transform.position -= fastSpeed;
            }
            else if (!pressed && obj.transform.position.x <= max.transform.position.x)
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
