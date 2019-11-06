using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour
{
    public GameObject bigHero;
    Vector3 bigHeroStartPos;
    public GameObject littleHero;
    Vector3 littleHeroStartPos;

    // Start is called before the first frame update
    void Start()
    {
        bigHeroStartPos = bigHero.transform.localPosition;
        littleHeroStartPos = littleHero.transform.localPosition;
    }

    public void respawn()
    {
        bigHero.transform.localPosition = bigHeroStartPos;
        littleHero.transform.localPosition = littleHeroStartPos;
    }
}
