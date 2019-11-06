using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressSlider : MonoBehaviour
{
    public bool boxOn = false;
    public bool playerOn = false;
    public GameObject btnObject;
    public GameObject activatedObject; //this references the object this button activates

    public Sprite button;
    public Sprite buttonPressed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (boxOn || playerOn)
        {
            activatedObject.GetComponent<Slider>().Activate();
            btnObject.GetComponent<SpriteRenderer>().sprite = buttonPressed;
        }
        else
        {
            activatedObject.GetComponent<Slider>().Deactivate();
            btnObject.GetComponent<SpriteRenderer>().sprite = button;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerOn = true;

        } //end of collision detection 
        if (collision.tag == "Box")
        {
            boxOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerOn = false;

        } //end of collision detection 
        if (collision.tag == "Box")
        {
            boxOn = false;
        }
    }
}
