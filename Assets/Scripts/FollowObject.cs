using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{

    public GameObject followee;

    public Vector3 offset;

    void Start()
    {
        transform.position = new Vector3(followee.transform.position.x + offset.x, transform.position.y, followee.transform.position.x + offset.x);
    }

    void LateUpdate()
    {
        transform.position = new Vector3(followee.transform.position.x + offset.x, transform.position.y, followee.transform.position.x + offset.x);
    }
}
