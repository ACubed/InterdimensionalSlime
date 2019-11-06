using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSplit : MonoBehaviour
{
    // Start is called before the first frame update
    public LockToFriend ltk;  
    public Animator animator;
    public AnimatorOverrideController animOverideBlue;
    public GameObject littleBoy;
    public AnimatorOverrideController animOverideGreen;
    public Collider2D blueCollider;
    public Collider2D greenCollider;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!ltk.locked){
            animator.runtimeAnimatorController = animOverideGreen;
            littleBoy.GetComponent<Renderer>().enabled = true;
            blueCollider.isTrigger = true; greenCollider.isTrigger = false;

        } else {
            littleBoy.GetComponent<Renderer>().enabled = false;
            animator.runtimeAnimatorController = animOverideBlue;
            blueCollider.isTrigger = false; greenCollider.isTrigger = true;
        } //end
    }
}

