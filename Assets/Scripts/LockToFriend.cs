using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockToFriend : MonoBehaviour
{
    public GameObject friend;

    public bool locked = true;

    // Update is called once per frame
    void Update()
    {
        //the distance between me and my friend

        if (Input.GetButtonDown("Fire1") && Vector2.Distance(transform.position, friend.transform.position) <= 3f)
        {
            if (!locked)
            {

            }
            locked = !locked;
        }

        if (locked)
            transform.position = friend.transform.position + new Vector3(-2f, 0f, 0f);


    }
}
