using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitEffects : MonoBehaviour
{
    public GameObject biggerBlob;
    public GameObject smallerBlob;

    public SpriteRenderer splitSprite;
    public Sprite[] sprites;

    public float maxDistance;

    public LockToFriend lockToFriend;

    public float maxWidth = 6f;

    public bool split = false;

    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        particles.Stop(true);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(biggerBlob.transform.position, smallerBlob.transform.position);
        if (distance <= maxDistance && !lockToFriend.locked)
        {
            splitSprite.enabled = true;

            float distanceRatio = distance / maxDistance;
            transform.localScale = new Vector2(maxWidth * distanceRatio, transform.localScale.y);

            /*int currentFrame = (int)Mathf.Floor(distanceRatio * 3);
            if (currentFrame == 4) {
                currentFrame = 3;
            }*/
            splitSprite.sprite = sprites[2];
        }
        else
        {
            splitSprite.enabled = false;
        }

        transform.position = biggerBlob.transform.position + ((smallerBlob.transform.position - biggerBlob.transform.position)/2);
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);

        Vector3 vectorToTarget = biggerBlob.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = q;


        if (distance > maxDistance)
        {
            if (split == false)
            {
                particles.gameObject.SetActive(true);
                particles.transform.position = biggerBlob.transform.position + ((smallerBlob.transform.position - biggerBlob.transform.position) / 1.75f);
                //particles.time = 0;
                particles.Play(true);
            }
            split = true;
        }
        else
        {
            split = false;
        }
    }
}
